﻿using System.Threading.Tasks;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ElectronNET_API_Demos.Controllers
{
    public class ShortcutsController : Controller
    {
        public IActionResult Index()
        {
            if (HybridSupport.IsElectronActive)
            {
                Electron.GlobalShortcut.Register("CommandOrControl+Alt+K", async () =>
                {
                    var options = new MessageBoxOptions("You pressed the registered global shortcut keybinding.")
                    {
                        Type = MessageBoxType.info,
                        Title = "Success!"
                    };

                    await Electron.Dialog.ShowMessageBoxAsync(options);
                });

                Electron.App.WillQuit += arg => Task.Run(() => Electron.GlobalShortcut.UnregisterAll());
            }

            return View();
        }
    }
}