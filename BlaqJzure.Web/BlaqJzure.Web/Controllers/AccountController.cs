﻿using BlaqJzure.Common.Models.Accounts.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // Registration
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(UserRegistrations userRegistrations)
    {
        var role = "User";
        var user = new IdentityUser { UserName = userRegistrations.username, Email = userRegistrations.email, EmailConfirmed = true };
        var result = await _userManager.CreateAsync(user, userRegistrations.password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, role);
            return RedirectToAction("Index", "Cart");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View();
    }

    // Login
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(UserLogin userLogin)
    {
        var user = await _userManager.FindByEmailAsync(userLogin.emailOrUserName)
                   ?? await _userManager.FindByNameAsync(userLogin.emailOrUserName);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "User does not exist.");
            return View();
        }

        if (!user.EmailConfirmed)
        {
            ModelState.AddModelError(string.Empty, "Please confirm your email to log in.");
            return View();
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName, userLogin.password, false, false);
        if (result.Succeeded)
        {
            HttpContext.Session.SetString("UserId", user.Id);
            return RedirectToAction("Index", "Cart");
        }

        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View();
    }
    // Logout
    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Remove("UserId");
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // Access Denied
    public IActionResult AccessDenied() => View();
}