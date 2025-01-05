![WebExpress](https://raw.githubusercontent.com/ReneSchwarzer/WebExpress/main/assets/banner.png)

# WebExpress
`WebExpress` is a lightweight web server optimized for use in low-performance environments (e.g. Rasperry PI). By providing 
a powerful plugin system and a comprehensive API, web applications can be easily and quickly integrated into a .net 
language (e.g. C#). Some advantages of `WebExpress` are:

- It is easy to use.
- It offers a variety of features and tools that can help you build and manage your website.
- It is fast and efficient and can help you save time and money.
- It is flexible and can be customized to meet your specific requirements.

The `WebExpress` family includes the following projects:

- [WebExpress](https://github.com/ReneSchwarzer/WebExpress#readme) - The web server for `WebExpress` applications and the documentation.
- [WebExpress.WebCore](https://github.com/ReneSchwarzer/WebExpress.WebCore#readme) - The core for `WebExpress` applications.
- [WebExpress.WebUI](https://github.com/ReneSchwarzer/WebExpress.WebUI#readme) - Common templates and controls for `WebExpress` applications.
- [WebExpress.WebIndex](https://github.com/ReneSchwarzer/WebExpress.WebIndex#readme) - Reverse index for `WebExpress` applications.
- [WebExpress.WebApp](https://github.com/ReneSchwarzer/WebExpress.WebApp#readme) - Business application template for `WebExpress` applications.

`WebExpress` is part of the `WebExpress` family. The project provides a web server for `WebExpress` applications.

To get started with `WebExpress`, use the following links.

- [installation guide](https://github.com/ReneSchwarzer/WebExpress/blob/main/doc/installation_guide.md) 
- [development guide](https://github.com/ReneSchwarzer/WebExpress/blob/main/doc/development_guide.md)

# Tutorial
How to tutorial to demonstrate a simple `WebExpress` application. The application includes the creation of a home page that displays this tutorial and an info page with information about the application.

## Prerequisites
- Install .NET 9.0. You can download and install .NET 9.0 from the official .NET website. Follow the instructions on the website to complete the installation.
- Verify the installation. Open the command line or terminal and run the following command:

  ```bash
  dotnet --version
  ```

  This command outputs the installed .NET version. Make sure the outputted version matches the version you installed (in this case 9.0).

After fulfilling these prerequisites, you can proceed with the tutorial.

## Create a new solution
- Open the command line or terminal.
    - On Windows, you can open the command line by typing cmd into the search box of the Start menu and pressing Enter.
    - On MacOS or Linux, you can open the terminal by typing terminal into the Spotlight search and pressing Enter.
- Navigate to the desired directory.
- Use the command cd `path/to/directory` to navigate to the desired directory.
- Create a new solution. Enter the following command and press Enter:

  ```bash
  # create a new folder for your solution
  mkdir WebExpress.Tutorial.WebApp
  cd WebExpress.Tutorial.WebApp

  # create a new solution
  dotnet new sln -n WebExpress.Tutorial.WebApp

  # create a new console application
  dotnet new console -n WebApp.App -f net9.0

  # create a new class library
  dotnet new classlib -n WebApp -f net9.0

  # add the projects to the solution
  dotnet sln add ./WebApp.App/WebApp.App.csproj
  dotnet sln add ./WebApp/WebApp.csproj
  ```

This command creates a new .NET solution named `WebExpress.Tutorial.WebApp` and uses .NET 9.0 as the framework.
- Check the newly created solution. There should now be a new directory named `WebExpress.Tutorial.WebApp` in the current directory. You can view the contents of this directory with the command ls (Linux/Mac) or dir (Windows).
- Open the solution in your preferred development environment.
  - If you are using Visual Studio Code, you can open the solution with the command `code .` in the solution directory.

Now you have created a new solution and are ready to proceed with the next steps in your tutorial.

## Customize the project
- Add the necessary dependencies in the `WebApp` project file.

  ```xml
  <PropertyGroup>
      ...
      <EnableDynamicLoading>true</EnableDynamicLoading>
  </PropertyGroup>

  <ItemGroup>
      <PackageReference Include="WebExpress.WebCore" Version="0.0.8-alpha">
          <Private>false</Private>
          <ExcludeAssets>runtime</ExcludeAssets>
      </PackageReference>

      <PackageReference Include="WebExpress.WebUI" Version="0.0.8-alpha">
          <Private>false</Private>
          <ExcludeAssets>runtime</ExcludeAssets>
      </PackageReference>

      <PackageReference Include="WebExpress.WebIndex" Version="0.0.8-alpha">
          <Private>false</Private>
          <ExcludeAssets>runtime</ExcludeAssets>
      </PackageReference>

      <PackageReference Include="WebExpress.WebApp" Version="0.0.8-alpha">
          <Private>false</Private>
          <ExcludeAssets>runtime</ExcludeAssets>
      </PackageReference>
  </ItemGroup>
  ```

- Add the necessary dependencies in the `WebApp.App` project file.

  ```xml
  <ItemGroup>
      <PackageReference Include="WebExpress.WebCore" Version="0.0.8-alpha" />
      <PackageReference Include="WebExpress.WebUI" Version="0.0.8-alpha" />
      <PackageReference Include="WebExpress.WebIndex" Version="0.0.8-alpha" />
      <PackageReference Include="WebExpress.WebApp" Version="0.0.8-alpha" />
  </ItemGroup>

  <ItemGroup>
      <ProjectReference Include="../WebApp/WebApp.csproj" />
  </ItemGroup>
  ```

- Adjust the project file to your requirements.

## Configure the WebExpress package
- Add a file named `WebExpress.Tutorial.WebApp.spec` in the solution folder.

  ```xml
  <?xml version="1.0" encoding="utf-8"?>
  <package>
      <id>WebExpress.Tutorial.WebApp</id>
      <version>0.0.8-alpha</version>
      <title>WebApp</title>
      <authors>rene_schwarzer@hotmail.de</authors>
      <license>MIT</license>
      <icon>icon.png</icon>
      <readme>README.md</readme>
      <privacypolicy>PrivacyPolicy.md</privacypolicy>
      <description>Provides a simple WebExpress application.</description>
      <tags>webexpress tutorial</tags>
      <plugin>WebApp</plugin>
  </package>
  ```

- Adjust the spec file to your requirements.
- Add the spec file in the `WebApp.App` project file.

  ```
  <Target Name="PostBuild" AfterTargets="PostBuildEvent" Condition="'$(Configuration)' == 'Release'">
      <Exec Command="$(SolutionDir)$(AssemblyName)/bin/$(Configuration)/$(TargetFramework)/$(AssemblyName).exe -s $(SolutionDir)/$(SolutionName).spec -c $(Configuration) -t $(TargetFramework) -o $(SolutionDir)/pkg/$(Configuration)" />
  </Target>
  ```

## Create a WebExpress plugin
- Create a new class `Plugin` in the `WebApp` project that implements the `IPlugin` interface.

  ```csharp
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebPlugin;

  namespace WebApp
  {
      [Name("webapp:plugin.name")]
      [Description("webapp:plugin.description")]
      [Icon("/assets/img/webapp.svg")]
      [Application<Application>()]
      public sealed class Plugin : IPlugin
      {
          public void Run() {}
      }
  }
  ```
- Adjust the class to your requirements.

## Create a WebExpress application
- Create a new class `Application` in the `WebApp` project that implements the `IApplication` interface.

  ```csharp
  using WebExpress.WebCore.WebApplication;
  using WebExpress.WebCore.WebAttribute;

  namespace WebApp
  {
      [Name("webapp:app.name")]
      [Description("webapp:app.description")]
      [Icon("/assets/img/webapp.svg")]
      [ContextPath("/webapp")]
      public sealed class Application : IApplication
      {
          public void Run() {}
     }
  }
  ```
- Adjust the class to your requirements.

## Create a home page
- Create a new view for the home page in the `WebApp` project.

  ```csharp
  using WebExpress.WebApp.WebPage;
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebResource;
  using WebExpress.WebCore.WebScope;
  using WebExpress.WebUI.WebControl;

  namespace WebApp.WebPage
  {
      [Title("webapp:homepage.label")]
      [Segment(null, "webapp:homepage.label")]
      [Scope<IScopeGeneral>]
      public sealed class HomePage : IPage<VisualTreeWebApp>, IScopeGeneral
      {
          public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree) {}
      }
  }
  ```

- Adjust the homepage to your requirements.
- Copy this radme file in the solution directory and add the in the `WebApp` project file. 

  ```xml
  <ItemGroup>
      <EmbeddedResource Include="../README.md" />
  </ItemGroup>
  ```

## Create a info page
- Create a new view for the info page in the `WebApp` project.

  ```csharp
  using System.Linq;
  using WebExpress.WebApp.WebPage;
  using WebExpress.WebCore.Internationalization;
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebComponent;
  using WebExpress.WebCore.WebResource;
  using WebExpress.WebCore.WebScope;
  using WebExpress.WebUI.WebControl;

  namespace WebApp.WebPage
  {
      [Title("webapp:infopage.label")]
      [Segment("info", "webapp:infopage.label")]
      [Scope<IScopeGeneral>]
      public sealed class InfoPage : IPage<VisualTreeWebApp>, IScopeGeneral
      {
          public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
          {
              var webexpress = WebEx.ComponentHub.PluginManager.Plugins.Where(x => x.PluginId.ToString() == "webexpress.webapp").FirstOrDefault();
              var webapp = WebEx.ComponentHub.PluginManager.Plugins.Where(x => x.Assembly == GetType().Assembly).FirstOrDefault();
         
              visualTree.Content.Primary.Add(new ControlImage()
              {
                  Uri = renderContext.PageContext.ContextPath.Append("assets/img/webapp.svg"),
                  Width = 200,
                  Height = 200,
                  HorizontalAlignment = TypeHorizontalAlignment.Right
              });
         
              var card = new ControlPanelCard()
              {
                  Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
              };
         
              card.Add(new ControlText()
              {
                  Text = I18N.Translate(renderContext.Request?.Culture, "webapp:app.name"),
                  Format = TypeFormatText.H3
              });
         
              card.Add(new ControlText()
              {
                  Text = I18N.Translate(renderContext.Request?.Culture, "webapp:app.description"),
                  Format = TypeFormatText.Paragraph
              });
         
              card.Add(new ControlText()
              {
                  Text = I18N.Translate(renderContext.Request?.Culture, "webapp:app.about"),
                  Format = TypeFormatText.H3
              });
         
              card.Add(new ControlText()
              {
                  Text = string.Format
                  (
                      I18N.Translate(renderContext.Request?.Culture, "webapp:app.version.label"),
                      I18N.Translate(renderContext.Request?.Culture, webapp?.PluginName),
                      webapp?.Version,
                      webexpress?.PluginName,
                      webexpress?.Version
                  ),
                  TextColor = new PropertyColorText(TypeColorText.Primary)
              });
         
              visualTree.Content.Primary.Add(card);
          }
      }
  }
  ```

## Add a fragment for the content of the home page
- Create a new fragment to view the content in the `WebApp` project.

  ```csharp
  using System.IO;
  using WebApp.WebPage;
  using WebExpress.WebApp.WebSection;
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebHtml;
  using WebExpress.WebCore.WebPage;
  using WebExpress.WebUI.WebAttribute;
  using WebExpress.WebUI.WebControl;
  using WebExpress.WebUI.WebFragment;

  namespace WebApp.WebFragment
  {
      [Section<SectionContentPrimary>]
      [Scope<HomePage>]
      [Cache]
      public sealed class HomeContentFragment : FragmentControlPanel
      {
          public HomeContentFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
          {
              using var stream = GetType().Assembly.GetManifestResourceStream("WebApp.README.md");
              using var reader = new StreamReader(stream);

              Add(new ControlText()
              {
                  Format = TypeFormatText.Markdown,
                  Text = reader.ReadToEnd()
              });
          }
      }
  }
  ```
- Adjust the fragment to your requirements.

## Add a fragment for the link to the home page
- Create a new fragment to link the home page in the `WebApp` project.

  ```csharp
  using WebApp.WebPage;
  using WebExpress.WebApp.WebSection;
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebComponent;
  using WebExpress.WebCore.WebHtml;
  using WebExpress.WebCore.WebPage;
  using WebExpress.WebUI.WebAttribute;
  using WebExpress.WebUI.WebControl;
  using WebExpress.WebUI.WebFragment;

  namespace WebApp.WebFragment
  {
      [Section<SectionAppNavigationPrimary>]
      [Scope<IScopeGeneral>]
      [Cache]
      public sealed class HomeLinkFragment : FragmentControlNavigationItemLink
      {
          public HomeFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
          {
              Text = "webapp:homepage.label";
              Uri = componentHub.SitemapManager.GetUri<HomePage>(fragmentContext.ApplicationContext);
              Icon = new PropertyIcon(TypeIcon.Home);
          }

          public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
          {
              Active = renderContext.Endpoint is HomePage ? TypeActive.Active : TypeActive.None;

              return base.Render(renderContext, visualTree);
          }
      }
  }
  ```

- Adjust the fragment to your requirements.

## Add a fragment for the link to the info page
- Create a new fragment to link the info page in the `WebApp` project.

  ```csharp
  using WebApp.WebPage;
  using WebExpress.WebApp.WebSection;
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebComponent;
  using WebExpress.WebCore.WebHtml;
  using WebExpress.WebCore.WebPage;
  using WebExpress.WebUI.WebAttribute;
  using WebExpress.WebUI.WebControl;
  using WebExpress.WebUI.WebFragment;

  namespace WebApp.WebFragment
  {
      [Section<SectionAppNavigationSecondary>]
      [Scope<IScopeGeneral>]
      [Cache]
      public sealed class InfoLinkFragment : FragmentControlNavigationItemLink
      {
          public InfoFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
              : base(fragmentContext)
          {
              Text = "webapp:infopage.label";
              Uri = componentHub.SitemapManager.GetUri<InfoPage>(fragmentContext.ApplicationContext);
              Icon = new PropertyIcon(TypeIcon.InfoCircle);
          }

          public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
          {
              Active = renderContext.Endpoint is InfoPage ? TypeActive.Active : TypeActive.None;

              return base.Render(renderContext, visualTree);
          }
      }
  }
  ```

- Adjust the fragment to your requirements.

## Add a fragment for the page footer
- Create a new fragment to view the footer in the `WebApp` project.

  ```csharp
  using WebExpress.WebApp.WebSection;
  using WebExpress.WebCore.Internationalization;
  using WebExpress.WebCore.WebAttribute;
  using WebExpress.WebCore.WebHtml;
  using WebExpress.WebCore.WebPage;
  using WebExpress.WebUI.WebAttribute;
  using WebExpress.WebUI.WebControl;
  using WebExpress.WebUI.WebFragment;

  namespace WebApp.WebFragment
  {
      [Section<SectionFooterPrimary>]
      [Scope<IScopeGeneral>]
      public sealed class FooterFragment : FragmentControlPanel
      {
          private ControlLink LicenceLink { get; } = new ControlLink()
          {
              TextColor = new PropertyColorText(TypeColorText.Muted),
              Size = new PropertySizeText(TypeSizeText.Small)
          };
    
          public FooterFragment(IFragmentContext fragmentContext)
              : base(fragmentContext)
          {
              Classes.Add("text-center");
    
              Add(LicenceLink);
          }
    
          public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
          {
              LicenceLink.Text = "webapp:app.license.label";
              LicenceLink.Uri = I18N.Translate(renderContext.Request?.Culture, "webapp:app.license.uri");
    
              return base.Render(renderContext, visualTree);
          }
      }
  }
  ```

- Adjust the fragment to your requirements.

## Change the program class
- Change the program class of the `WebApp.App` project as follows:

  ```csharp
  using System.Reflection;

  namespace HalloWorld.App
  {
      internal class Program
      {
          static void Main(string[] args)
          {
              var app = new WebExpress.WebCore.WebEx()
              {
                  Name = Assembly.GetExecutingAssembly().GetName().Name
              };

              app.Execution(args);
          }
      }
  }
  ```

## Internationalization
- Add support for multiple languages. This can be achieved by using i18n files. Each resource file contains the translations for all strings in your application. Name your resource files according to the culture they represent. For example, the file for German translations should be called `de``. In the following, we use the english language.

 ```
  plugin.name=WebApp
  plugin.description=Tutorial of a simple WebExprss application.

  app.name=WebApp Tutorial
  app.label=WebExprss Application
  app.description=Tutorial of a simple WebExpress application.
  app.license.label=License MIT 
  app.license.uri=https://github.com/ReneSchwarzer/WebExpress.Tutorial.WebApp/blob/main/LICENSE
  app.about=About WebApp Tutorial
  app.version.label={0} version {1} created with {2} version {3}.

  module.name=WebApp
  module.description=Module of the WebApp application.

  homepage.label=Home page
  infopage.label=Info
  ```

  - Add the en file in the `WebApp` project file.
  
  ```xml
  <ItemGroup>
      <EmbeddedResource Include="Internationalization/en" />
  </ItemGroup>
  ```

## Add the Assets
- Add assets to the `WebApp` project. You can get the assets for this tutorial here: https://github.com/ReneSchwarzer/WebExpress.Tutorial.WebApp/tree/main/WebApp/Assets/img
- Add the assets in the `WebApp` project file.

  ```xml
  <ItemGroup>
      <EmbeddedResource Include="Assets/img/favicon.png" />
      <EmbeddedResource Include="Assets/img/webapp.svg" />
  </ItemGroup>
  ```

## Add a Configuration
- The application must be configured. A standard configuration must be delivered for this purpose. Add the configuration file to the `WebApp.App` project.

  ```xml
  <?xml version="1.0" encoding="utf-8" ?>
  <config version = "1">
      <log modus="Off" debug="false" path="/var/log/" encoding="utf-8" filename="webexpress.log" timepattern="dd.MM.yyyy HH:mm:ss" />
      <uri>http://localhost/</uri>
      <endpoint uri="http://localhost/"/>
      <limit>
          <connectionlimit>300</connectionlimit>
          <uploadlimit>3000000000</uploadlimit>
      </limit>
      <culture>en</culture>
      <packages>./packages</packages>
      <assets>./assets</assets>
      <data>./data</data>
      <contextpath></contextpath>
  </config>
  ```

- Include the configuration file in the `WebApp.App` project file.

  ```
  <ItemGroup>
      <None Update="config/webexpress.config.xml">
          <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
      </None>
  </ItemGroup>
  ```

## Compile and register in WebExpress
- Compile the solution as a release. To do this, open the command line or terminal in the solution directory and run the following command:

  ```bash
  dotnet build --configuration Release
  ```
  This command compiles the solution in release mode. You can find the compiled files in the `bin/Release` directory of your project.

- Run the solution by starting the `WebApp.App` project.

  ```bash
  cd WebApp.App\bin\Release\net9.0
  dotnet run --project ../../../WebApp.App.csproj
  ```

- After compiling, there should be a file with the `.wxp` extension in the `pkg/Release` directory. This file do you need in `WebExpress`.

## Try the application
- Check the result by calling up the following URL in the browser: [http://localhost/webapp](http://localhost/webapp)
- Good luck!
    
# Tags
#WebExpress #WebServer #WebCore #WebUI #Tutorial #DotNet
