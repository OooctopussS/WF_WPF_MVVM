   M S B A M L   `   `   `  ?????  ;lab5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:lab5.ViewModelslab5.ViewModels  5   	   clr-namespace:lab5lab5  5   	       lab5.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,vmclr-namespace:lab5.ViewModels     5   	   $localclr-namespace:lab5     5   	     ? Title$  
MainWindow??5	   	   $	??600??6   $	??800??6)   "   lab5.ViewModels.SizeObserver   Observe$
 True??5
   	      ObservedWidth 5   	   ?? *WidthWindow+ ?? Mode$ OneWayToSource=?   ObservedHeight 5   	   ?? *HeightWindow+$ OneWayToSource=? J? InputBindings 5      ?? 5   
   
 ?? Key$ H??6    ?? Command 6   ?? *SelectedItemMoveLeftCommand+ ?? CommandParameter 6M   ?? *SelectedItemToDraw+?? 5   
   $ L??6    6   ?? *SelectedItemMoveRightCommand+ 6N   ?? *SelectedItemToDraw+?? 5   
   $ K??6    6   ?? *SelectedItemMoveTopCommand+ 6L   ?? *SelectedItemToDraw+?? 5   
   $ J??6    6   ?? *SelectedItemMoveBottomCommand+ 6O   ?? *SelectedItemToDraw+	 ? DataContext	 5      )  #lab5.ViewModels.MainWindowViewModel  5   
   .??5      ]? .+?5   
   A? 
 K? ZIndex$
 2??6   $??Bottom=?6'    A? Columns$ 3??6?   .+?5      ?? $%??Добавить квадрат??6   $??10,10,10,10q?60   $??20, 0, 0, 10q?6F   ??6\   ?? *CreateSquareWithBorderCommand+6?   ?? 5      $???9Добавить дорожный знак 'Кирпич'??6   $??20, 0, 20, 10q?6?   ??6V   ?? *CreateStopSignCommand+6?   ?? 5      $4??.Добавить надпись 'Налево'??6   $??0, 0, 20, 10q?69   ??6O   ?? *CreateLeftTextCommand+6{   5      ]? 5   
   $
 2??6   $??Right=?6%   $??0, 20, 0, 20q?6<   .+?5      ?? $??Bottom=?6   $#??Удалить элемент??6-   $??0, 10q?6G   ??6W   ?? *DeleteItemToDrawCommand+??6?   ?? *SelectedItemToDraw+?? 5      -   5         ??Name$ ItemToDrawList??5      $	??200??60    ?? DisplayMemberPath$
 Name??6j   ??6<   ?? *ItemsCollectionToDraw+ ?? SelectedItem 6?   ?? *SelectedItemToDraw+5      ?? 5    
   $
 1??6   ??6*   ?? *CanvasPanel+5!      5#      5%      