﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArbitesEto2
{
    public class MdMetaUtil
    {

        public static List<string> GetListOfInputMethods()
        {
            return (Directory.GetFiles(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_INPUT_METHOD), "*" + MdConstant.E_INPUT_METHOD).ToList());
        }

        public static void FirstRunCheck()
        {

            if (!File.Exists(Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG)))
            {
                ResetDefaults();
            }
        }


        public static void ResetDefaults()
        {
            if (!Directory.Exists(MdPersistentData.ConfigPath))
            {
                Directory.CreateDirectory(MdPersistentData.ConfigPath);
            }
            CreateDefaultConfig();
            CreateDefaultInputMethods();
            CreateDefaultKeyboards();
            CreateDefaultKeygroups();

            MdSessionData.Init();
        }

        public static void CreateDefaultConfig()
        {

            MdCore.Serialize<MdConfig>(new MdConfig(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.N_CONFIG));
        }

        public static void CreateDefaultKeyboards()
        {
            if (!Directory.Exists(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD)))
            {
                Directory.CreateDirectory(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD));
            }

            MdCore.Serialize<ClKeyboard>(ClKeyboard.GenerateDiverge2(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "diverge-2-3" + MdConstant.E_KEYBOARD));
            var d2r = ClKeyboard.GenerateDiverge2();
            d2r.Commands[0] = "uniqueksetsubkey";
            d2r.Commands[1] = "uniqueksetkey";
            MdCore.Serialize<ClKeyboard>(d2r, Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "diverge-2-3-rightmaster" + MdConstant.E_KEYBOARD));
            MdCore.Serialize<ClKeyboard>(ClKeyboard.GenerateDivergeTM(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "diverge-tm-1-2" + MdConstant.E_KEYBOARD));
            var dtmr = ClKeyboard.GenerateDivergeTM();
            dtmr.Commands[0] = "uniqueksetsubkey";
            dtmr.Commands[1] = "uniqueksetkey";
            MdCore.Serialize<ClKeyboard>(dtmr, Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "diverge-tm-1-2-rightmaster" + MdConstant.E_KEYBOARD));
            MdCore.Serialize<ClKeyboard>(ClKeyboard.GenerateTerminusMini(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "terminus-mini" + MdConstant.E_KEYBOARD));
            MdCore.Serialize<ClKeyboard>(ClKeyboard.GenerateFelix(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYBOARD, "felix" + MdConstant.E_KEYBOARD));
        }

        public static void CreateDefaultKeygroups()
        {
            if (!Directory.Exists(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYGROUP)))
            {
                Directory.CreateDirectory(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYGROUP));
            }

            MdCore.Serialize<ClKeyGroup>(ClKeyGroup.GenerateDefault(), Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_KEYGROUP, "Core" + MdConstant.E_KEYGROUP));
        }


        public static void CreateDefaultInputMethods()
        {
            if (!Directory.Exists(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_INPUT_METHOD)))
            {
                Directory.CreateDirectory(Path.Combine(MdPersistentData.ConfigPath, MdConstant.D_INPUT_METHOD));
            }

            MdCore.Serialize<ClDisplayCharacterContainer>(ClDisplayCharacterContainer.GenerateUSASCII()
                , Path.Combine(
                MdPersistentData.ConfigPath
                , MdConstant.D_INPUT_METHOD,
                "US-ASCII" + MdConstant.E_INPUT_METHOD));


        }


        public static void ReloadInputMethodUI()
        {
            if (MdSessionData.CurrentKeyboardUI != null)
            {

                if (MdSessionData.CurrentKeyboardUI.Layers != null)
                {
                    MdSessionData.CurrentKeyboardUI.LoadLayout(MdSessionData.CurrentLayout);
                }
            }
            if (MdSessionData.KeyMenu != null)
            {

                if (MdSessionData.KeyMenu.Loaded)
                {

                    MdSessionData.KeyMenu.ReloadInputMethod();
                }
            }
        }
    }
}
