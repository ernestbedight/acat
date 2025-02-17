﻿////////////////////////////////////////////////////////////////////////////
//
// Copyright 2013-2019; 2023 Intel Corporation
// SPDX-License-Identifier: Apache-2.0
//
////////////////////////////////////////////////////////////////////////////

using System;

namespace ACAT.Lib.Core.Utility
{
    /// <summary>
    /// All dynamically discovered and loaded classes such as
    /// Scanners, Dialogs, Menus, App Agents, Actuators, Word Predictors
    /// should have a descriptor attribute that includes a unique
    /// GUID, a friendly name and a friendly description.  This class
    /// encapsulates all this information.
    /// </summary>
    public class DescriptorAttribute : Attribute, IDescriptor
    {
        /// <summary>
        /// Category (user-defined)
        /// </summary>
        private String _category;

        /// <summary>
        /// Friendly description
        /// </summary>
        private String _description;

        /// <summary>
        /// Unique identifier
        /// </summary>
        private Guid _guid;

        /// <summary>
        /// Friendly name
        /// </summary>
        private String _name;

        /// <summary>
        /// Initializes an instance of the class
        /// </summary>
        /// <param name="id">GUID id</param>
        /// <param name="name">friendly name</param>
        /// <param name="description">description</param>
        public DescriptorAttribute(String id, String name, String description)
        {
            _name = name;
            _category = String.Empty;
            _description = description;
            if (!Guid.TryParse(id, out _guid))
            {
                _guid = Guid.Empty;
            }
        }

        /// <summary>
        /// Initializes an instance of the class
        /// </summary>
        /// <param name="id">GUID id</param>
        /// <param name="name">friendly name</param>
        /// <param name="description">description</param>
        public DescriptorAttribute(String id, String name, String category, String description)
        {
            _name = name;
            _description = description;
            _category = category;
            if (!Guid.TryParse(id, out _guid))
            {
                _guid = Guid.Empty;
            }
        }

        /// <summary>
        /// Gets the category
        /// </summary>
        public string Category
        {
            get
            {
                return _category;
            }
        }

        /// <summary>
        /// Gets the description
        /// </summary>
        public String Description
        {
            get
            {
                return _description;
            }
        }

        /// <summary>
        /// Gets the unique id
        /// </summary>
        public Guid Id
        {
            get
            {
                return _guid;
            }
        }

        /// <summary>
        /// Gets the name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Regurns the descriptor object for the class bu querying
        /// custom attributes and looking for the one that is of
        /// type DescriptorAttribute
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DescriptorAttribute GetDescriptor(Type type)
        {
            foreach (object attribute in type.GetCustomAttributes(true))
            {
                if (attribute is DescriptorAttribute)
                {
                    return attribute as DescriptorAttribute;
                }
            }

            return null;
        }
    }
}