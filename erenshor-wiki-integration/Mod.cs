using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace erenshor_wiki_integration
{
    [BepInPlugin(Metadata.MOD_GUID, Metadata.MOD_NAME, Metadata.MOD_VERSION)]
    public class Mod : BaseUnityPlugin
    {
        public static Mod Instance;
        private readonly Harmony harmony = new Harmony(Metadata.MOD_GUID);
        private ConfigEntry<KeyboardShortcut> _wikiHotkey;

        private Item _currentItem;

        //Mod initialization
        public void Awake()
        {
            Instance = this;

            harmony.PatchAll();

            _wikiHotkey = Config.Bind("General", 
                "Hotkey", 
                new KeyboardShortcut(UnityEngine.KeyCode.BackQuote), 
                "Hotkey for opening up wiki of items in inventory");
        }

        public void Update()
        {
            if (_wikiHotkey.Value.IsDown())
                OpenWiki();
        }

        public void SetHoveredItem(Item Item)
        {
            _currentItem = Item;
        }

        public void ClearHoveredItem()
        {
            _currentItem = null;
        }

        string CleanItemName(string ItemName)
        {
            return ItemName.Replace(' ', '_');
        }

        void OpenWiki()
        {
            if (_currentItem == null)
                return;

            string WikiName = CleanItemName(_currentItem.ItemName);
            Application.OpenURL($"{Metadata.WIKI_BASE_URL}/{WikiName}");
        }
    }
}
