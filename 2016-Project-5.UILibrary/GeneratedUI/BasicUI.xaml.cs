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
    public partial class BasicUI : UIRoot {
        
        private Grid e_0;
        
        private TextBlock label2;
        
        private TextBox txtBxuserName;
        
        private TextBlock label3;
        
        private PasswordBox passBxPassword;
        
        private TextBlock lblfrgtPass;
        
        private Button btnLogin;
        
        private TextBlock lblLoading;
        
        private Button btnClose;
        
        private TextBlock label4;
        
        public BasicUI() : 
                base() {
            this.Initialize();
        }
        
        public BasicUI(int width, int height) : 
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
            this.Background = new SolidColorBrush(new ColorW(0, 0, 0, 0));
            this.Foreground = new SolidColorBrush(new ColorW(0, 0, 0, 0));
            Binding binding__OwnedWindowsContent = new Binding("Windows");
            this.SetBinding(UIRoot.OwnedWindowsContentProperty, binding__OwnedWindowsContent);
            // e_0 element
            this.e_0 = new Grid();
            this.Content = this.e_0;
            this.e_0.Name = "e_0";
            this.e_0.Height = 171F;
            this.e_0.Width = 359F;
            this.e_0.Background = new SolidColorBrush(new ColorW(41, 39, 39, 255));
            // label2 element
            this.label2 = new TextBlock();
            this.e_0.Children.Add(this.label2);
            this.label2.Name = "label2";
            this.label2.Height = 30F;
            this.label2.Width = 79F;
            this.label2.Margin = new Thickness(106F, 50F, 0F, 0F);
            this.label2.HorizontalAlignment = HorizontalAlignment.Left;
            this.label2.VerticalAlignment = VerticalAlignment.Top;
            this.label2.Foreground = new SolidColorBrush(new ColorW(255, 185, 0, 255));
            this.label2.Text = "User Name";
            this.label2.FontFamily = new FontFamily("Arial");
            this.label2.FontSize = 12F;
            Grid.SetColumn(this.label2, 1);
            Grid.SetRow(this.label2, 1);
            // txtBxuserName element
            this.txtBxuserName = new TextBox();
            this.e_0.Children.Add(this.txtBxuserName);
            this.txtBxuserName.Name = "txtBxuserName";
            this.txtBxuserName.Height = 30F;
            this.txtBxuserName.Width = 157F;
            this.txtBxuserName.Margin = new Thickness(183F, 0F, 0F, 90F);
            this.txtBxuserName.HorizontalAlignment = HorizontalAlignment.Left;
            this.txtBxuserName.VerticalAlignment = VerticalAlignment.Bottom;
            this.txtBxuserName.Background = new SolidColorBrush(new ColorW(0, 0, 0, 0));
            this.txtBxuserName.BorderBrush = new SolidColorBrush(new ColorW(255, 255, 255, 255));
            this.txtBxuserName.Foreground = new SolidColorBrush(new ColorW(255, 255, 255, 255));
            this.txtBxuserName.VerticalContentAlignment = VerticalAlignment.Center;
            this.txtBxuserName.FontFamily = new FontFamily("Arial");
            this.txtBxuserName.FontSize = 12F;
            Grid.SetColumn(this.txtBxuserName, 1);
            Grid.SetRow(this.txtBxuserName, 1);
            // label3 element
            this.label3 = new TextBlock();
            this.e_0.Children.Add(this.label3);
            this.label3.Name = "label3";
            this.label3.Height = 29F;
            this.label3.Width = 79F;
            this.label3.Margin = new Thickness(106F, 85F, 0F, 0F);
            this.label3.HorizontalAlignment = HorizontalAlignment.Left;
            this.label3.VerticalAlignment = VerticalAlignment.Top;
            this.label3.Foreground = new SolidColorBrush(new ColorW(255, 185, 0, 255));
            this.label3.Text = "Password";
            this.label3.FontFamily = new FontFamily("Arial");
            this.label3.FontSize = 12F;
            Grid.SetColumn(this.label3, 1);
            Grid.SetRow(this.label3, 1);
            // passBxPassword element
            this.passBxPassword = new PasswordBox();
            this.e_0.Children.Add(this.passBxPassword);
            this.passBxPassword.Name = "passBxPassword";
            this.passBxPassword.Height = 30F;
            this.passBxPassword.Width = 157F;
            this.passBxPassword.Margin = new Thickness(183F, 0F, 0F, 55F);
            this.passBxPassword.HorizontalAlignment = HorizontalAlignment.Left;
            this.passBxPassword.VerticalAlignment = VerticalAlignment.Bottom;
            this.passBxPassword.Background = new SolidColorBrush(new ColorW(0, 0, 0, 0));
            this.passBxPassword.BorderBrush = new SolidColorBrush(new ColorW(255, 255, 255, 255));
            this.passBxPassword.Foreground = new SolidColorBrush(new ColorW(255, 255, 255, 255));
            this.passBxPassword.VerticalContentAlignment = VerticalAlignment.Center;
            this.passBxPassword.FontFamily = new FontFamily("Arial");
            this.passBxPassword.FontSize = 12F;
            this.passBxPassword.SelectionBrush = new SolidColorBrush(new ColorW(255, 177, 74, 255));
            this.passBxPassword.PasswordChar = '*';
            Grid.SetColumn(this.passBxPassword, 1);
            Grid.SetRow(this.passBxPassword, 1);
            // lblfrgtPass element
            this.lblfrgtPass = new TextBlock();
            this.e_0.Children.Add(this.lblfrgtPass);
            this.lblfrgtPass.Name = "lblfrgtPass";
            this.lblfrgtPass.Height = 28F;
            this.lblfrgtPass.Width = 126F;
            this.lblfrgtPass.Visibility = Visibility.Hidden;
            this.lblfrgtPass.Margin = new Thickness(106F, 124F, 0F, 0F);
            this.lblfrgtPass.HorizontalAlignment = HorizontalAlignment.Left;
            this.lblfrgtPass.VerticalAlignment = VerticalAlignment.Top;
            this.lblfrgtPass.Foreground = new SolidColorBrush(new ColorW(255, 255, 255, 255));
            this.lblfrgtPass.Text = "Forgot Password ?";
            this.lblfrgtPass.FontFamily = new FontFamily("Arial");
            this.lblfrgtPass.FontSize = 12F;
            this.lblfrgtPass.FontStyle = FontStyle.Regular;
            Grid.SetColumn(this.lblfrgtPass, 1);
            Grid.SetRow(this.lblfrgtPass, 1);
            // btnLogin element
            this.btnLogin = new Button();
            this.e_0.Children.Add(this.btnLogin);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Height = 29F;
            this.btnLogin.Width = 75F;
            this.btnLogin.Margin = new Thickness(265F, 121F, 0F, 0F);
            this.btnLogin.HorizontalAlignment = HorizontalAlignment.Left;
            this.btnLogin.VerticalAlignment = VerticalAlignment.Top;
            this.btnLogin.CursorType = CursorType.Hand;
            this.btnLogin.Background = new SolidColorBrush(new ColorW(0, 0, 0, 0));
            this.btnLogin.BorderBrush = new SolidColorBrush(new ColorW(255, 255, 255, 255));
            this.btnLogin.Foreground = new SolidColorBrush(new ColorW(255, 185, 0, 255));
            this.btnLogin.FontFamily = new FontFamily("Arial");
            this.btnLogin.FontSize = 12F;
            this.btnLogin.Content = "Login";
            Grid.SetColumn(this.btnLogin, 1);
            Grid.SetRow(this.btnLogin, 1);
            // lblLoading element
            this.lblLoading = new TextBlock();
            this.e_0.Children.Add(this.lblLoading);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Height = 31F;
            this.lblLoading.Width = 77F;
            this.lblLoading.Visibility = Visibility.Hidden;
            this.lblLoading.Margin = new Thickness(22F, 121F, 0F, 0F);
            this.lblLoading.HorizontalAlignment = HorizontalAlignment.Left;
            this.lblLoading.VerticalAlignment = VerticalAlignment.Top;
            this.lblLoading.Text = "Loading ...";
            this.lblLoading.FontFamily = new FontFamily("Arial");
            Grid.SetColumn(this.lblLoading, 1);
            Grid.SetRow(this.lblLoading, 1);
            // btnClose element
            this.btnClose = new Button();
            this.e_0.Children.Add(this.btnClose);
            this.btnClose.Name = "btnClose";
            this.btnClose.Height = 22F;
            this.btnClose.Width = 22F;
            this.btnClose.Margin = new Thickness(336F, 0F, 0F, 0F);
            this.btnClose.HorizontalAlignment = HorizontalAlignment.Left;
            this.btnClose.VerticalAlignment = VerticalAlignment.Top;
            ToolTip tt_btnClose = new ToolTip();
            this.btnClose.ToolTip = tt_btnClose;
            tt_btnClose.Content = "Close";
            this.btnClose.CursorType = CursorType.Arrow;
            this.btnClose.Background = new SolidColorBrush(new ColorW(0, 0, 0, 0));
            this.btnClose.BorderBrush = new SolidColorBrush(new ColorW(0, 0, 0, 0));
            this.btnClose.BorderThickness = new Thickness(0F, 0F, 0F, 0F);
            this.btnClose.Foreground = new SolidColorBrush(new ColorW(255, 255, 255, 255));
            this.btnClose.FontSize = 12F;
            this.btnClose.Content = "X";
            Grid.SetColumn(this.btnClose, 1);
            Grid.SetRowSpan(this.btnClose, 2);
            // label4 element
            this.label4 = new TextBlock();
            this.e_0.Children.Add(this.label4);
            this.label4.Name = "label4";
            this.label4.VerticalAlignment = VerticalAlignment.Top;
            this.label4.Background = new SolidColorBrush(new ColorW(0, 0, 0, 0));
            this.label4.Foreground = new SolidColorBrush(new ColorW(255, 185, 0, 255));
            this.label4.Text = "Login";
            this.label4.FontFamily = new FontFamily("Arial");
            this.label4.FontSize = 12F;
            FontManager.Instance.AddFont("Arial", 12F, FontStyle.Regular, "Arial_9_Regular");
        }
    }
}
