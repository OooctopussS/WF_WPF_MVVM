using lab5.Commands;
using lab5.Models;
using lab5.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace lab5.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<ItemToDraw> ItemsCollectionToDraw { get; }

        public Canvas CanvasPanel { get; }

        private MouseBinding NewMouseBinding { get; set; }

        #region Размер панели - ширина
        private double _WidthWindow;

        public double WidthWindow
        {
            get => _WidthWindow;
            set => Set(ref _WidthWindow, value);
        }
        #endregion

        #region Размер панели - высота
        private double _HeightWindow;

        public double HeightWindow
        {
            get => _HeightWindow;
            set => Set(ref _HeightWindow, value);
        }
        #endregion

        #region Выбранный элемент списка
        private ItemToDraw _SelectedItemToDraw;

        public ItemToDraw SelectedItemToDraw
        {
            get => _SelectedItemToDraw;
            set
            {
                foreach (ItemToDraw item in ItemsCollectionToDraw)
                {
                    (item.Element as UserItemToDraw).IsSelected = false;
                    item.Element.InvalidateVisual();
                }
                Set(ref _SelectedItemToDraw, value);
                if (_SelectedItemToDraw != null)
                {
                    (_SelectedItemToDraw.Element as UserItemToDraw).IsSelected = true;
                    _SelectedItemToDraw.Element.InvalidateVisual();
                }
            }
        }
        #endregion

        #region Команды

        #region CreateSquareWithBorderCommand
        public ICommand CreateSquareWithBorderCommand { get; }

        private bool CanCreateSquareWithBorderCommandExecute(object p) => true;

        private void OnCreateSquareWithBorderCommandExecuted(object p)
        {
            ItemToDraw userControlItem = new()
            {
                Name = "Квадрат",
                Element = new SquareWithBorder()
            };

            SetCanvasLeftTopCoord(userControlItem);

            ItemsCollectionToDraw.Add(userControlItem);
            CanvasPanel.Children.Add(userControlItem.Element);

            AddInputBinding(userControlItem);

        }
        #endregion

        #region CreateStopSignCommand
        public ICommand CreateStopSignCommand { get; }

        private bool CanCreateStopSignCommandExecute(object p) => true;

        private void OnCreateStopSignCommandExecuted(object p)
        {
            ItemToDraw userControlItem = new()
            {
                Name = "Знак 'Кирпич'",
                Element = new StopSign()
            };

            SetCanvasLeftTopCoord(userControlItem);

            ItemsCollectionToDraw.Add(userControlItem);
            CanvasPanel.Children.Add(userControlItem.Element);

            AddInputBinding(userControlItem); ;
        }

        #endregion

        #region CreateLeftTextCommand
        public ICommand CreateLeftTextCommand { get; }

        private bool CanCreateLeftTextCommandExecute(object p) => true;

        private void OnCreateLeftTextCommandExecuted(object p)
        {
            ItemToDraw userControlItem = new()
            {
                Name = "Надпись 'Налево'",
                Element = new LeftText()
            };

            SetCanvasLeftTopCoord(userControlItem);

            ItemsCollectionToDraw.Add(userControlItem);
            CanvasPanel.Children.Add(userControlItem.Element);

            AddInputBinding(userControlItem);
        }

        #endregion

        #region DeleteItemToDrawCommand
        public ICommand DeleteItemToDrawCommand { get; }

        private bool CanDeleteItemToDrawCommandExecute(object p) => p is ItemToDraw item && ItemsCollectionToDraw.Contains(item);

        private void OnDeleteItemToDrawCommandExecuted(object p)
        {
            if (p is not ItemToDraw item) return;
            CanvasPanel.Children.Remove(item.Element);
            ItemsCollectionToDraw.Remove(item);
        }

        #endregion

        #region SelectItemOnClickCommand
        public ICommand SelectItemOnClickCommand { get; }

        private bool CanSelectItemOnClickCommandExecute(object p) => p is ItemToDraw item && ItemsCollectionToDraw.Contains(item);

        private void OnSelectItemOnClickCommandExecuted(object p)
        {
            if (p is not ItemToDraw item)
            {
                return;
            }

            SelectedItemToDraw = item;
        }

        #endregion

        #region SelectedItemMoveLeftCommand
        public ICommand SelectedItemMoveLeftCommand { get; }

        private bool CanSelectedItemMoveLeftCommandExecute(object p) => p is ItemToDraw;

        private void OnSelectedItemMoveLeftCommandExecuted(object p)
        {
            if (p is not ItemToDraw item || item != SelectedItemToDraw)
            {
                return;
            }
            Canvas.SetLeft(item.Element, (item.Element as UserItemToDraw).XPointCanvasLeft--);
        }
        #endregion

        #region SelectedItemMoveRightCommand
        public ICommand SelectedItemMoveRightCommand { get; }

        private bool CanSelectedItemMoveRightCommandExecute(object p) => p is ItemToDraw;

        private void OnSelectedItemMoveRightCommandExecuted(object p)
        {
            if (p is not ItemToDraw item || item != SelectedItemToDraw)
            {
                return;
            }
            Canvas.SetLeft(item.Element, (item.Element as UserItemToDraw).XPointCanvasLeft++);
        }
        #endregion

        #region SelectedItemMoveTopCommand
        public ICommand SelectedItemMoveTopCommand { get; }

        private bool CanSelectedItemMoveTopCommandExecute(object p) => p is ItemToDraw;

        private void OnSelectedItemMoveTopCommandExecuted(object p)
        {
            if (p is not ItemToDraw item || item != SelectedItemToDraw)
            {
                return;
            }
            Canvas.SetTop(item.Element, (item.Element as UserItemToDraw).YPointCanvasTop--);
        }
        #endregion

        #region SelectedItemMoveBottomCommand
        public ICommand SelectedItemMoveBottomCommand { get; }

        private bool CanSelectedItemMoveBottomCommandExecute(object p) => p is ItemToDraw;

        private void OnSelectedItemMoveBottomCommandExecuted(object p)
        {
            if (p is not ItemToDraw item || item != SelectedItemToDraw)
            {
                return;
            }
            Canvas.SetTop(item.Element, (item.Element as UserItemToDraw).YPointCanvasTop++);
        }
        #endregion

        #endregion

        private void AddInputBinding(ItemToDraw userControlItem)
        {
            NewMouseBinding = new MouseBinding()
            {
                Command = SelectItemOnClickCommand,
                CommandParameter = userControlItem,
                MouseAction = MouseAction.LeftClick
            };

            userControlItem.Element.InputBindings.Add(NewMouseBinding);
        }
        private void SetCanvasLeftTopCoord(ItemToDraw userControlItem)
        {
            Random rnd = new();
            (userControlItem.Element as UserItemToDraw).XPointCanvasLeft = rnd.Next(0 + 40, Convert.ToInt32(WidthWindow) - 300);
            (userControlItem.Element as UserItemToDraw).YPointCanvasTop = rnd.Next(0 + 40, Convert.ToInt32(HeightWindow) - 200);
            Canvas.SetLeft(userControlItem.Element, (userControlItem.Element as UserItemToDraw).XPointCanvasLeft);
            Canvas.SetTop(userControlItem.Element, (userControlItem.Element as UserItemToDraw).YPointCanvasTop);
        }

        public MainWindowViewModel()
        {
            #region Объявление команд

            CreateSquareWithBorderCommand = new ActionCommand(OnCreateSquareWithBorderCommandExecuted, CanCreateSquareWithBorderCommandExecute);
            CreateStopSignCommand = new ActionCommand(OnCreateStopSignCommandExecuted, CanCreateStopSignCommandExecute);
            CreateLeftTextCommand = new ActionCommand(OnCreateLeftTextCommandExecuted, CanCreateLeftTextCommandExecute);
            DeleteItemToDrawCommand = new ActionCommand(OnDeleteItemToDrawCommandExecuted, CanDeleteItemToDrawCommandExecute);
            SelectItemOnClickCommand = new ActionCommand(OnSelectItemOnClickCommandExecuted, CanSelectItemOnClickCommandExecute);
            SelectedItemMoveLeftCommand = new ActionCommand(OnSelectedItemMoveLeftCommandExecuted, CanSelectedItemMoveLeftCommandExecute);
            SelectedItemMoveRightCommand = new ActionCommand(OnSelectedItemMoveRightCommandExecuted, CanSelectedItemMoveRightCommandExecute);
            SelectedItemMoveTopCommand = new ActionCommand(OnSelectedItemMoveTopCommandExecuted, CanSelectedItemMoveTopCommandExecute);
            SelectedItemMoveBottomCommand = new ActionCommand(OnSelectedItemMoveBottomCommandExecuted, CanSelectedItemMoveBottomCommandExecute);

            #endregion

            CanvasPanel = new Canvas();
            ItemsCollectionToDraw = new ObservableCollection<ItemToDraw>();
        }
    }

    public static class SizeObserver
    {
        public static readonly DependencyProperty ObserveProperty = DependencyProperty.RegisterAttached(
            "Observe",
            typeof(bool),
            typeof(SizeObserver),
            new FrameworkPropertyMetadata(OnObserveChanged));

        public static readonly DependencyProperty ObservedWidthProperty = DependencyProperty.RegisterAttached(
            "ObservedWidth",
            typeof(double),
            typeof(SizeObserver));

        public static readonly DependencyProperty ObservedHeightProperty = DependencyProperty.RegisterAttached(
            "ObservedHeight",
            typeof(double),
            typeof(SizeObserver));

        public static bool GetObserve(FrameworkElement frameworkElement)
        {
            return (bool)frameworkElement.GetValue(ObserveProperty);
        }

        public static void SetObserve(FrameworkElement frameworkElement, bool observe)
        {
            frameworkElement.SetValue(ObserveProperty, observe);
        }

        public static double GetObservedWidth(FrameworkElement frameworkElement)
        {
            return (double)frameworkElement.GetValue(ObservedWidthProperty);
        }

        public static void SetObservedWidth(FrameworkElement frameworkElement, double observedWidth)
        {
            frameworkElement.SetValue(ObservedWidthProperty, observedWidth);
        }

        public static double GetObservedHeight(FrameworkElement frameworkElement)
        {
            return (double)frameworkElement.GetValue(ObservedHeightProperty);
        }

        public static void SetObservedHeight(FrameworkElement frameworkElement, double observedHeight)
        {
            frameworkElement.SetValue(ObservedHeightProperty, observedHeight);
        }

        private static void OnObserveChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = (FrameworkElement)dependencyObject;

            if ((bool)e.NewValue)
            {
                frameworkElement.SizeChanged += OnFrameworkElementSizeChanged;
                UpdateObservedSizesForFrameworkElement(frameworkElement);
            }
            else
            {
                frameworkElement.SizeChanged -= OnFrameworkElementSizeChanged;
            }
        }

        private static void OnFrameworkElementSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateObservedSizesForFrameworkElement((FrameworkElement)sender);
        }

        private static void UpdateObservedSizesForFrameworkElement(FrameworkElement frameworkElement)
        {
            frameworkElement.SetCurrentValue(ObservedWidthProperty, frameworkElement.ActualWidth);
            frameworkElement.SetCurrentValue(ObservedHeightProperty, frameworkElement.ActualHeight);
        }
    }

}
