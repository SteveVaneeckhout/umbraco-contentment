﻿/* Copyright © 2019 Lee Kelleher, Umbrella Inc and other contributors.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;
using Umbraco.Core.PropertyEditors;

namespace Umbraco.Community.Contentment.DataEditors
{
    internal static partial class ConfigurationFieldExtensions
    {
        public static void AddNotes(this List<ConfigurationField> fields, string notes, bool hideLabel = true)
        {
            fields.Add(new NotesConfigurationField(notes, hideLabel));
        }
    }
}
