using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ActionIcon
{
    public partial class ActionIcon : UserControl
    {
        public static readonly DependencyProperty ActionProperty = DependencyProperty.Register(
            nameof(Action),
            typeof(Icon),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(Icon.NONE, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ActionSourceProperty = DependencyProperty.Register(
            nameof(ActionSource),
            typeof(ImageSource),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty BaseSourceProperty = DependencyProperty.Register(
            nameof(BaseSource),
            typeof(ImageSource),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ModifierProperty = DependencyProperty.Register(
            nameof(Modifier),
            typeof(Icon),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(Icon.NONE, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ModifierSourceProperty = DependencyProperty.Register(
            nameof(ModifierSource),
            typeof(ImageSource),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(
            nameof(Status),
            typeof(Icon),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(Icon.NONE, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty StatusSourceProperty = DependencyProperty.Register(
            nameof(StatusSource),
            typeof(ImageSource),
            typeof(ActionIcon),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

        /// <summary>
        /// Constructor.
        /// </summary>
        public ActionIcon()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Icon used in the top left area
        /// </summary>
        [Description("Icon in the top left."), Category("Appearance")]
        public Icon Action
        {
            get => (Icon)GetValue(ActionProperty);
            set => SetValue(ActionProperty, value);
        }

        /// <summary>
        /// Custom source image for the top left area. Overwrites the Action property.
        /// </summary>
        [Description("Custom source for the icon in the top left. The Action property will have no effect."), Category("Appearance")]
        public ImageSource ActionSource
        {
            get => (ImageSource)GetValue(ActionSourceProperty);
            set => SetValue(ActionSourceProperty, value);
        }

        /// <summary>
        /// Source image of the base reference icon.
        /// </summary>
        [Description("Source of the main icon."), Category("Appearance")]
        public ImageSource BaseSource
        {
            get => (ImageSource)GetValue(BaseSourceProperty);
            set => SetValue(BaseSourceProperty, value);
        }

        /// <summary>
        /// Icon used in the bottom left area
        /// </summary>
        [Description("Icon in the bottom left."), Category("Appearance")]
        public Icon Modifier
        {
            get => (Icon)GetValue(ModifierProperty);
            set => SetValue(ModifierProperty, value);
        }

        /// <summary>
        /// Custom source image for the bottom left area. Overwrites the Action property.
        /// </summary>
        [Description("Custom source for the icon in the bottom left. The Modifier property will have no effect."), Category("Appearance")]
        public ImageSource ModifierSource
        {
            get => (ImageSource)GetValue(ModifierSourceProperty);
            set => SetValue(ModifierSourceProperty, value);
        }

        /// <summary>
        /// Icon used in the bottom right area
        /// </summary>
        [Description("Icon in the bottom right."), Category("Appearance")]
        public Icon Status
        {
            get => (Icon)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        /// <summary>
        /// Custom source image for the bottom right area. Overwrites the Action property.
        /// </summary>
        [Description("Custom source for the icon in the bottom right. The Status property will have no effect."), Category("Appearance")]
        public ImageSource StatusSource
        {
            get => (ImageSource)GetValue(StatusSourceProperty);
            set => SetValue(StatusSourceProperty, value);
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == BaseSourceProperty)
                baseImage.Source = (ImageSource)e.NewValue;
            else if (e.Property == ActionSourceProperty)
                actionImage.Source = (ImageSource)e.NewValue;
            else if (e.Property == StatusSourceProperty)
                statusImage.Source = (ImageSource)e.NewValue;
            else if (e.Property == ModifierSourceProperty)
                modifierImage.Source = (ImageSource)e.NewValue;
            else if (e.Property == ActionProperty && ActionSource == null)
                actionImage.Source = TryFindResource(GetIconKey((Icon)e.NewValue)) as ImageSource;
            else if (e.Property == StatusProperty && StatusSource == null)
                statusImage.Source = TryFindResource(GetIconKey((Icon)e.NewValue)) as ImageSource;
            else if (e.Property == ModifierProperty && ModifierSource == null)
                modifierImage.Source = TryFindResource(GetIconKey((Icon)e.NewValue)) as ImageSource;
        }

        private string GetIconKey(Icon icon) => icon switch
        {
            Icon.NONE => "None",
            Icon.ADD => "Add",
            Icon.ALERT => "Alert",
            Icon.DELETE => "Delete",
            Icon.DOWNLOAD => "Download",
            Icon.EDIT => "Edit",
            Icon.EDIT_REVERSE => "EditReverse",
            Icon.ERROR => "Error",
            Icon.FIND => "Find",
            Icon.HELP => "Help",
            Icon.IMPORT => "Import",
            Icon.INFO => "Info",
            Icon.LOCK => "Lock",
            Icon.NEW => "New",
            Icon.NEXT => "Next",
            Icon.NO => "No",
            Icon.OK => "Ok",
            Icon.OPEN => "Open",
            Icon.PAUSE => "Pause",
            Icon.PREVIOUS => "Previous",
            Icon.REDO => "Redo",
            Icon.REFRESH => "Refresh",
            Icon.REMOVE => "Remove",
            Icon.RUN => "Run",
            Icon.SAVE => "Save",
            Icon.STAR => "Star",
            Icon.STOP => "Stop",
            Icon.SYNC => "Sync",
            Icon.UNDO => "Undo",
            Icon.UPLOAD => "Upload",
            Icon.WARNING => "Warning",
            _ => null,
        };
    }
}