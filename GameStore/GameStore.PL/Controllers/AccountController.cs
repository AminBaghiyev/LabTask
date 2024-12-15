﻿using GameStore.DAL.Models;
using GameStore.PL.Utilities;
using GameStore.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.PL.Controllers;

public class AccountController : Controller
{
    readonly UserManager<AppUser> _userManager;
    readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Register()
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterUserVM form)
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }

        if (!ModelState.IsValid)
        {
            return View(form);
        }

        AppUser user = new()
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            UserName = form.UserName
        };

        var result = await _userManager.CreateAsync(user, form.Password);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View();
        }

        await _userManager.AddToRoleAsync(user, Roles.User.ToString());

        return RedirectToAction(nameof(Login));
    }

    public IActionResult Login()
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginUserVM form)
    {
        if (User.Identity is not null && User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }

        if (!ModelState.IsValid)
        {
            return View(form);
        }

        AppUser? user = await _userManager.FindByNameAsync(form.UserName);

        if (user is null)
        {
            ModelState.AddModelError("CustomError", "Fields are wrong!");
            return View(form);
        }

        var result = await _signInManager.PasswordSignInAsync(user, form.Password, form.RememberMe, true);
        if (!result.Succeeded && !result.IsLockedOut)
        {
            ModelState.AddModelError("CustomError", "Fields are wrong!");
            return View(form);
        }

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}
