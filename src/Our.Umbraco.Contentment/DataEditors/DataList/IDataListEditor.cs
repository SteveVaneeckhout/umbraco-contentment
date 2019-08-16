﻿/* Copyright © 2019 Lee Kelleher, Umbrella Inc and other contributors.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;

namespace Umbraco.Community.Contentment.DataEditors
{
    public interface IDataListEditor : IContentmentListItem
    {
        Dictionary<string, object> DefaultConfig { get; }

        string View { get; }
    }
}
