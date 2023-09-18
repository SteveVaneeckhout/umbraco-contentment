﻿/* Copyright © 2019 Lee Kelleher.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

#if NET472
using System.Collections.Generic;
using Umbraco.Core.IO;
using Umbraco.Core.PropertyEditors;
using Umbraco.Core.Strings;
using UmbConstants = Umbraco.Core.Constants;
#else
using System.Collections.Generic;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Serialization;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;
using UmbConstants = Umbraco.Cms.Core.Constants;
#endif

namespace Umbraco.Community.Contentment.DataEditors
{
    public sealed class TextboxListDataEditor : IDataEditor
    {
        internal const string DataEditorAlias = Constants.Internals.DataEditorAliasPrefix + "TextboxList";
        internal const string DataEditorName = Constants.Internals.DataEditorNamePrefix + "Textbox List";
        internal const string DataEditorViewPath = Constants.Internals.EditorsPathRoot + "textbox-list.html";
        internal const string DataEditorIcon = "icon-ordered-list";

        private readonly IIOHelper _ioHelper;
        private readonly IShortStringHelper _shortStringHelper;
        private readonly ConfigurationEditorUtility _utility;

        public string Alias => DataEditorAlias;

        public EditorType Type => EditorType.PropertyValue;

        public string Name => DataEditorName;

        public string Icon => DataEditorIcon;

        public string Group => UmbConstants.PropertyEditors.Groups.Common;

        public bool IsDeprecated => false;

        public IDictionary<string, object> DefaultConfiguration => default;

        public IPropertyIndexValueFactory PropertyIndexValueFactory => new DefaultPropertyIndexValueFactory();

#if NET472
        public TextboxListDataEditor(
            ConfigurationEditorUtility utility,
            IIOHelper ioHelper,
            IShortStringHelper shortStringHelper)
        {
            _utility = utility;
            _ioHelper = ioHelper;
            _shortStringHelper = shortStringHelper;
        }
#else
        private readonly ILocalizedTextService _localizedTextService;
        private readonly IJsonSerializer _jsonSerializer;

        public TextboxListDataEditor(
            ConfigurationEditorUtility utility,
            IIOHelper ioHelper,
            ILocalizedTextService localizedTextService,
            IShortStringHelper shortStringHelper,
            IJsonSerializer jsonSerializer)
        {
            _utility = utility;
            _ioHelper = ioHelper;
            _localizedTextService = localizedTextService;
            _shortStringHelper = shortStringHelper;
            _jsonSerializer = jsonSerializer;
        }
#endif

        public IConfigurationEditor GetConfigurationEditor() => new TextboxListConfigurationEditor(_utility, _ioHelper, _shortStringHelper);

        public IDataValueEditor GetValueEditor()
        {
#if NET472
            return new DataValueEditor()
#else
            return new DataValueEditor(_localizedTextService, _shortStringHelper, _jsonSerializer)
#endif
            {
                ValueType = ValueTypes.Json,
                View = _ioHelper.ResolveRelativeOrVirtualUrl(Constants.Internals.EmptyEditorViewPath),
            };
        }

        public IDataValueEditor GetValueEditor(object configuration)
        {
#if NET472
            return new DataValueEditor()
#else
            return new DataValueEditor(_localizedTextService, _shortStringHelper, _jsonSerializer)
#endif
            {
#if NET8_0_OR_GREATER
                ConfigurationObject = configuration,
#else
                Configuration = configuration,
#endif
                ValueType = ValueTypes.Json,
                View = _ioHelper.ResolveRelativeOrVirtualUrl(DataEditorViewPath),
            };
        }
    }
}
