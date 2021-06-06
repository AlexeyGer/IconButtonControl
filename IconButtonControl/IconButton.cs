using System;
using System.Collections.Generic;
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
using IconButtonControl.Enums;

namespace IconButtonControl
{
	/// <summary>
	/// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
	///
	/// Step 1a) Using this custom control in a XAML file that exists in the current project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:IconButtonControl"
	///
	///
	/// Step 1b) Using this custom control in a XAML file that exists in a different project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:IconButtonControl;assembly=IconButtonControl"
	///
	/// You will also need to add a project reference from the project where the XAML file lives
	/// to this project and Rebuild to avoid compilation errors:
	///
	///     Right click on the target project in the Solution Explorer and
	///     "Add Reference"->"Projects"->[Select this project]
	///
	///
	/// Step 2)
	/// Go ahead and use your control in the XAML file.
	///
	///     <MyNamespace:CustomControl1/>
	///
	/// </summary>
	public class IconButton : Button
	{
		static IconButton() //TODO: Vector format
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
		}

		public IconButton()
		{
			this.SetCurrentValue(IconButton.IconPositionProperty, Enums.IconPosition.Left);
		}

		public ImageSource IconSource
		{
			get { return (ImageSource)GetValue(IconSourceProperty); }
			set { SetValue(IconSourceProperty, value); }
		}

		public static readonly DependencyProperty IconSourceProperty =
			DependencyProperty.Register(nameof(IconSource), typeof(ImageSource), typeof(IconButton), new PropertyMetadata(null));

		public int Row
		{
			get { return (int)GetValue(RowProperty); }
			set { SetValue(RowProperty, value); }
		}

		public static readonly DependencyProperty RowProperty =
			DependencyProperty.Register(nameof(Row), typeof(int), typeof(IconButton), new PropertyMetadata(0));

		public int Column
		{
			get { return (int)GetValue(ColumnProperty); }
			set { SetValue(ColumnProperty, value); }
		}

		public static readonly DependencyProperty ColumnProperty =
			DependencyProperty.Register(nameof(Column), typeof(int), typeof(IconButton), new PropertyMetadata(0));

		public IconPosition IconPosition
		{
			get { return (IconPosition)GetValue(IconPositionProperty); }
			set { SetValue(IconPositionProperty, value); }
		}

		public static readonly DependencyProperty IconPositionProperty =
			DependencyProperty.Register(nameof(IconPosition), typeof(IconPosition?), typeof(IconButton), new PropertyMetadata(null, PropertyChangedCallback));

		private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var imageButton = (IconButton)d;
			var newPosition = (IconPosition?)e.NewValue ?? Enums.IconPosition.Left;

			switch (newPosition)
			{
				case Enums.IconPosition.Center:
					imageButton.SetCurrentValue(IconButton.RowProperty, 1);
					imageButton.SetCurrentValue(IconButton.ColumnProperty, 1);
					break;
				case Enums.IconPosition.Left:
					imageButton.SetCurrentValue(IconButton.RowProperty, 1);
					imageButton.SetCurrentValue(IconButton.ColumnProperty, 0);
					break;
				case Enums.IconPosition.Right:
					imageButton.SetCurrentValue(IconButton.RowProperty, 1);
					imageButton.SetCurrentValue(IconButton.ColumnProperty, 2);
					break;
				case Enums.IconPosition.Top:
					imageButton.SetCurrentValue(IconButton.RowProperty, 0);
					imageButton.SetCurrentValue(IconButton.ColumnProperty, 1);
					break;
				case Enums.IconPosition.Bottom:
					imageButton.SetCurrentValue(IconButton.RowProperty, 2);
					imageButton.SetCurrentValue(IconButton.ColumnProperty, 1);
					break;

				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}

