﻿////////////////////////////////////////////////////////////////////////////
//
// Copyright 2013-2019; 2023 Intel Corporation
// SPDX-License-Identifier: Apache-2.0
//
////////////////////////////////////////////////////////////////////////////

using ACAT.Lib.Core.PreferencesManagement;
using System;

namespace ACAT.Lib.Core.Utility
{
    /// <summary>
    /// Language-specific settings, loaded from a file
    /// </summary>
    [Serializable]
    public class LanguageSettings : PreferencesBase
    {
        /// <summary>
        /// If any of these characters are typed, any whitespaces
        /// before them are delted
        /// </summary>
        public String DeletePrecedingSpacesChars = ".? !,:;@})]";

        /// <summary>
        /// If any of these characters are typed, a space is automatically
        /// inserted after the character
        /// </summary>
        public String InsertSpaceAfterChars = ".?!,:;})]";

        /// <summary>
        /// List of characters that are treated as sentence terminators
        /// </summary>
        public String SentenceTerminatorChars = "?!.";

        /// <summary>
        /// These are sentence punctuations, they terminate the
        /// sentence or phrases in a sentence
        /// </summary>
        public String TerminatorChars = ".?!,:;";

        /// <summary>
        /// Returns true if the specifed character is one of the characters
        /// whose preceding white spaces will be deleted.
        /// </summary>
        /// <param name="ch">character</param>
        /// <returns>true if it is</returns>
        public bool IsDeletePrecedingSpacesChar(char ch)
        {
            return DeletePrecedingSpacesChars.IndexOf(ch) >= 0;
        }

        /// <summary>
        /// Returns true if the specifed character is one of the characters
        /// after which a space is automatically inserted.
        /// </summary>
        /// <param name="ch">character</param>
        /// <returns>true if it is</returns>
        public bool IsInsertSpaceAfterChar(char ch)
        {
            return InsertSpaceAfterChars.IndexOf(ch) >= 0;
        }

        /// <summary>
        /// Returns true if the specifed character is a sentence terminator.
        /// </summary>
        /// <param name="ch">character</param>
        /// <returns>true if it is</returns>
        public bool IsSentenceTerminatorChar(char ch)
        {
            return SentenceTerminatorChars.IndexOf(ch) >= 0;
        }

        /// <summary>
        /// Returns true if the specifed character is a sentence phrase
        /// terminator
        /// </summary>
        /// <param name="ch">character</param>
        /// <returns>true if it is</returns>
        public bool IsTerminatorChar(char ch)
        {
            return TerminatorChars.IndexOf(ch) >= 0;
        }

        /// <summary>
        /// Saves the settings to the settings file
        /// </summary>
        /// <returns>true on success</returns>
        public override bool Save()
        {
            return true;
        }
    }
}