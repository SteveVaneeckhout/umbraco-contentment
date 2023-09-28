<img src="../assets/img/logo.png" alt="Contentment for Umbraco logo" title="A state of Umbraco happiness." height="130" align="right">

## Contentment for Umbraco

### Icon Picker

Icon Picker is a property-editor that is used to pick a single icon from Umbraco's default icon set.


### How to configure the editor?

In your new Data Type, selected the "[Contentment] Icon Picker" option. You will see the following configuration fields.

![Configuration Editor for Icon Picker](icon-picker--configuration-editor.png)

The main field is **Default icon**, with this you can define the default icon for the property.


### How to use the editor?

Once you have added the configured Data Type to your Document Type, the Icon Picker editor will be displayed on the content page's property panel.

![Icon Picker property-editor - default state](icon-picker--property-editor-01.png)

By clicking on the icon box, will open Umbraco's icon picker overlay. Text filters and color selection can also be used.

![Icon Picker property-editor - icon picker overlay open, selecting icon](icon-picker--property-editor-02.png)

Having picked your icon, the selected icon will be displayed in the icon box.

![Icon Picker property-editor - selected state](icon-picker--property-editor-03.png)


### How to get the value?

The value for the Icon Picker is a `string` in the form of `"icon-{name} color-{name}"` (e.g. `"icon-hat color-black"`). To use this in your view templates, here are some examples.

Assuming that your property's alias is `"icon"`, then...

Using Umbraco's Models Builder...

```cshtml
<i class="icon @Model.Icon"></i>
```

Without ModelsBuilder...

Weakly-typed...

```cshtml
<i class="icon @Model.Value("icon")"></i>
```

Strongly-typed...

```cshtml
<i class="icon @(Model.Value<string>("icon"))"></i>
```

#### Backoffice SVG icon support

If you wanted to render the SVG of the icon from the backoffice, you can do so by using the [`IIconService`](https://github.com/umbraco/Umbraco-CMS/blob/release-10.0.0/src/Umbraco.Core/Services/IIconService.cs) and calling the `.GetIcon()` method to the SVG markup.

Here is an example in a Razor page view, on .NET Core, (Umbraco v9+).

```cshtml
@inject Umbraco.Cms.Core.Services.IIconService _iconService
@inherits UmbracoViewPage
@{
    // NOTE: You will need to split the value by space,
    // as the value contains both the icon's alias and color name.
    var iconAlias = Model.Icon.Split(' ').FirstOrDefault();
    var iconSvg = _iconService.GetIcon(iconAlias);
}

<style>
    .my-icon > svg {
        height: 64px;
        width: 64px;
        fill: blue;
    }
</style>

<div class="my-icon">
    @Html.Raw(iconSvg.SvgString)
</div>
```


### How to configure as a parameter-editor?

Icon Picker is available as a macro parameter-editor by default. It will automatically be listed in the parameter options for your macros.


### Further reading

For a list of available icons in Umbraco, [Nic Bell's UCreate project has a page for them](https://nicbell.github.io/ucreate/icons.html).
