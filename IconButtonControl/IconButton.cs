using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
		static IconButton()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
		}

		public IconButton()
		{
			this.SetCurrentValue(IconPositionProperty, IconPosition.Left);
		}

		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register(nameof(Text), typeof(string), typeof(IconButton), new PropertyMetadata());

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public static readonly DependencyProperty IconSourceProperty =
			DependencyProperty.Register(nameof(IconSource), typeof(Geometry), typeof(IconButton), new PropertyMetadata(null));

		public Geometry IconSource
		{
			get { return (Geometry)GetValue(IconSourceProperty); }
			set { SetValue(IconSourceProperty, value); }
		}

		public static readonly DependencyProperty IconWidthProperty =
			DependencyProperty.Register(nameof(IconWidth), typeof(int), typeof(IconButton), new PropertyMetadata(30));

		public int IconWidth
		{
			get { return (int)GetValue(IconWidthProperty); }
			set { SetValue(IconWidthProperty, value); }
		}

		public static readonly DependencyProperty IconHeightProperty =
			DependencyProperty.Register(nameof(IconHeight), typeof(int), typeof(IconButton), new PropertyMetadata(30));

		public int IconHeight
		{
			get { return (int)GetValue(IconHeightProperty); }
			set { SetValue(IconHeightProperty, value); }
		}

		public static readonly DependencyProperty IconBrushProperty =
			DependencyProperty.Register(nameof(IconBrush), typeof(string), typeof(IconButton), new PropertyMetadata("Black"));

		public string IconBrush
		{
			get { return (string)GetValue(IconBrushProperty); }
			set { SetValue(IconBrushProperty, value); }
		}

		public static readonly DependencyProperty IconPositionProperty =
			DependencyProperty.Register(nameof(IconPosition), typeof(IconPosition?), typeof(IconButton), new PropertyMetadata(null, PropertyChangedCallback));

		public IconPosition IconPosition
		{
			get { return (IconPosition)GetValue(IconPositionProperty); }
			set { SetValue(IconPositionProperty, value); }
		}

		public static readonly DependencyProperty RowProperty =
			DependencyProperty.Register(nameof(Row), typeof(int), typeof(IconButton), new PropertyMetadata(0));

		public int Row
		{
			get { return (int)GetValue(RowProperty); }
			set { SetValue(RowProperty, value); }
		}

		public static readonly DependencyProperty ColumnProperty =
			DependencyProperty.Register(nameof(Column), typeof(int), typeof(IconButton), new PropertyMetadata(0));

		public int Column
		{
			get { return (int)GetValue(ColumnProperty); }
			set { SetValue(ColumnProperty, value); }
		}

		private static void PropertyChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			var iconButton = (IconButton)obj;
			var newPosition = (IconPosition?)args.NewValue ?? IconPosition.Left;

			switch (newPosition)
			{
				case IconPosition.Center:
					iconButton.SetCurrentValue(RowProperty, 1);
					iconButton.SetCurrentValue(ColumnProperty, 1);
					break;
				case IconPosition.Left:
					iconButton.SetCurrentValue(RowProperty, 1);
					iconButton.SetCurrentValue(ColumnProperty, 0);
					break;
				case IconPosition.Right:
					iconButton.SetCurrentValue(RowProperty, 1);
					iconButton.SetCurrentValue(ColumnProperty, 2);
					break;
				case IconPosition.Top:
					iconButton.SetCurrentValue(RowProperty, 0);
					iconButton.SetCurrentValue(ColumnProperty, 1);
					break;
				case IconPosition.Bottom:
					iconButton.SetCurrentValue(RowProperty, 2);
					iconButton.SetCurrentValue(ColumnProperty, 1);
					break;

				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}

