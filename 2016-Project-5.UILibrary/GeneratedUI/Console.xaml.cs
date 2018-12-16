// -----------------------------------------------------------
//  
//  This file was generated, please do not modify.
//  
// -----------------------------------------------------------
namespace EmptyKeys.UserInterface.Generated {
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.ObjectModel;
    using EmptyKeys.UserInterface;
    using EmptyKeys.UserInterface.Charts;
    using EmptyKeys.UserInterface.Data;
    using EmptyKeys.UserInterface.Controls;
    using EmptyKeys.UserInterface.Controls.Primitives;
    using EmptyKeys.UserInterface.Input;
    using EmptyKeys.UserInterface.Interactions.Core;
    using EmptyKeys.UserInterface.Interactivity;
    using EmptyKeys.UserInterface.Media;
    using EmptyKeys.UserInterface.Media.Animation;
    using EmptyKeys.UserInterface.Media.Imaging;
    using EmptyKeys.UserInterface.Shapes;
    using EmptyKeys.UserInterface.Renderers;
    using EmptyKeys.UserInterface.Themes;
    
    
    [GeneratedCodeAttribute("Empty Keys UI Generator", "2.1.0.0")]
    public partial class Console : UIRoot {
        
        private Grid e_0;
        
        private TextBlock ConsoleTextBlock;
        
        private DockPanel e_1;
        
        private ScrollViewer Scroller;
        
        private DockPanel e_2;
        
        private TextBox e_3;
        
        public Console() : 
                base() {
            this.Initialize();
        }
        
        public Console(int width, int height) : 
                base(width, height) {
            this.Initialize();
        }
        
        private void Initialize() {
            Style style = RootStyle.CreateRootStyle();
            style.TargetType = this.GetType();
            this.Style = style;
            this.InitializeComponent();
        }
        
        private void InitializeComponent() {
            this.Background = new SolidColorBrush(new ColorW(0, 0, 0, 255));
            this.Foreground = new SolidColorBrush(new ColorW(255, 255, 255, 255));
            Binding binding__OwnedWindowsContent = new Binding("Windows");
            this.SetBinding(UIRoot.OwnedWindowsContentProperty, binding__OwnedWindowsContent);
            // e_0 element
            this.e_0 = new Grid();
            this.Content = this.e_0;
            this.e_0.Name = "e_0";
            RowDefinition row_e_0_0 = new RowDefinition();
            this.e_0.RowDefinitions.Add(row_e_0_0);
            RowDefinition row_e_0_1 = new RowDefinition();
            row_e_0_1.Height = new GridLength(30F, GridUnitType.Pixel);
            this.e_0.RowDefinitions.Add(row_e_0_1);
            // ConsoleTextBlock element
            this.ConsoleTextBlock = new TextBlock();
            this.e_0.Children.Add(this.ConsoleTextBlock);
            this.ConsoleTextBlock.Name = "ConsoleTextBlock";
            this.ConsoleTextBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.ConsoleTextBlock.VerticalAlignment = VerticalAlignment.Stretch;
            this.ConsoleTextBlock.Text = "Console contents...";
            // e_1 element
            this.e_1 = new DockPanel();
            this.e_0.Children.Add(this.e_1);
            this.e_1.Name = "e_1";
            Grid.SetRow(this.e_1, 0);
            // Scroller element
            this.Scroller = new ScrollViewer();
            this.e_1.Children.Add(this.Scroller);
            this.Scroller.Name = "Scroller";
            this.Scroller.Margin = new Thickness(0F, 0F, 0F, 0F);
            this.Scroller.Background = new SolidColorBrush(new ColorW(0, 0, 0, 255));
            // e_2 element
            this.e_2 = new DockPanel();
            this.e_0.Children.Add(this.e_2);
            this.e_2.Name = "e_2";
            Grid.SetRow(this.e_2, 1);
            // e_3 element
            this.e_3 = new TextBox();
            this.e_2.Children.Add(this.e_3);
            this.e_3.Name = "e_3";
            FontManager.Instance.AddFont("Arial", 12F, FontStyle.Regular, "Arial_9_Regular");
        }
    }
}
