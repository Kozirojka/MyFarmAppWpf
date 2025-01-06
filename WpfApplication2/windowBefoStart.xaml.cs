using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication2.slimeMovement;

namespace WpfApplication2
{
    public class PointsOfBuilding
    {
        public int XBuilding;
        public int YBuilding;
        public int TypeBuilding;
        public string nameOfEnemy;
        public bool Improved = false;
        
        public PointsOfBuilding(int yBuilding, int xBuilding, int typeBuilding, string nameEnemy)
        {
            this.YBuilding = yBuilding;
            this.XBuilding = xBuilding;
            TypeBuilding = typeBuilding;
            nameOfEnemy = nameEnemy;
        }
    }


    class BuildingMaker
    {
        public IBuilding basic =
            new PlainBuilding.BuildingLevelTwo((new PlainBuilding()));
        
        public IBuilding basicSecond =
            new PlainBuilding.buildingLever3(new PlainBuilding.BuildingLevelTwo(new PlainBuilding()));

    }

    
    
    public partial class windowBefoStart : Window
    {
        private BuildingMaker _designer = new BuildingMaker();
        public Tractor _tractor = new Tractor();
        FieldProcessingDevice fieldProcessingDevice = new FieldProcessingDevice();
        NavigationPanel navigationPanel = new NavigationPanel();
        
        
        public playerF fox = new playerF();
        internal Ferm farmMap = new Ferm();
        private DifficultyLevelFactory difficultyLevelFactory;
        SoundPlayerFacade openSoundPlayer = new SoundPlayerFacade();
        private List<PointsOfBuilding> listOfbuildings;
        private BitmapImage[] moneyFrames;
        private int currentMoneyFrameIndex = 0;

        public FarmFacade worker = new FarmFacade();

        /// <summary>
        private Image petImage;

        private BitmapImage[] petFrames;
        private int currentPetFrameIndex = 0;
        private bool isPetMoving = true;

        /// </summary>
        private bool isFarmCreated = false;

        private static windowBefoStart instance;

        BitmapImage[] sunnyFrames;
        BitmapImage[] rainyFrames;
        BitmapImage[] windyFrames;

        public static windowBefoStart GetInstance(DifficultyLevelFactory difficultyLevelFactoryP)
        {
            if (instance == null)
            {
                instance = new windowBefoStart(difficultyLevelFactoryP);
            }

            return instance;
        }


        public windowBefoStart(DifficultyLevelFactory difficultyLevelFactoryP)
        {
            this.difficultyLevelFactory = difficultyLevelFactoryP;

            InitializeComponent();
            InitializeGame();
            AnimateCoin();
            WeatherLooop();
            listOfbuildings = new List<PointsOfBuilding>();
        }


        private Image moneyIcon;

        private async Task InitializeGame()
        {
            fox.animationFrames = new BitmapImage[8];
            fox.animationFrames[0] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\imageForFox\\output-onlinepngtools.png"));
            fox.animationFrames[1] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\imageForFox\\output-onlinepngtools (1).png"));
            fox.animationFrames[2] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\imageForFox\\output-onlinepngtools (2).png"));
            fox.animationFrames[3] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\imageForFox\\output-onlinepngtools (3).png"));
            fox.animationFrames[4] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\imageForFox\\output-onlinepngtools (5).png"));
            fox.animationFrames[5] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\imageForFox\\output-onlinepngtools (6).png"));
            fox.animationFrames[6] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\imageForFox\\output-onlinepngtools (7).png"));
            fox.animationFrames[7] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\imageForFox\\output-onlinepngtools (8).png"));

            // Create the player (fox image)
            fox.player = new Image
            {
                Source = fox.animationFrames[fox.currentFrameIndex],
                Width = 50,
                Height = 50
            };

            // Initialize player position
            fox.playerX = 100;
            fox.playerY = 100;
            Canvas.SetLeft(fox.player, fox.playerX);
            Canvas.SetTop(fox.player, fox.playerY);

            GameCanvas.Children.Add(fox.player);

            fox.flipTransform = new ScaleTransform();
            fox.player.RenderTransformOrigin = new Point(0.5, 0.5);
            fox.player.RenderTransform = fox.flipTransform;


            KeyDown += MainWindow_KeyDown;

            moneyFrames = new BitmapImage[4];
            moneyFrames[0] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\coinFrame\\coin_frame.png"));
            moneyFrames[1] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\coinFrame\\coin_frame2.png"));
            moneyFrames[2] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\coinFrame\\coin_frame3.png"));
            moneyFrames[3] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\coinFrame\\coin_frame2.png"));

            moneyIcon = new Image
            {
                Source = moneyFrames[currentMoneyFrameIndex],
                Width = 25,
                Height = 25
            };

            Canvas.SetRight(moneyIcon, 10);
            Canvas.SetTop(moneyIcon, 10);

            GameCanvas.Children.Add(moneyIcon);

            sunnyFrames = new BitmapImage[1];
            sunnyFrames[0] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\sunnyICON\\Screenshot_1-Photoroom.png-Photoroom.png"));


            rainyFrames = new BitmapImage[8];
            rainyFrames[0] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\rainyICON\\rainy1.png"));
            rainyFrames[1] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\rainyICON\\rainy2.png"));
            rainyFrames[2] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\rainyICON\\rainy3.png"));
            rainyFrames[3] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\rainyICON\\rainy4.png"));
            rainyFrames[4] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\rainyICON\\rainy5.png"));
            rainyFrames[5] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\rainyICON\\rainy6.png"));
            rainyFrames[6] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\rainyICON\\rainy7.png"));
            rainyFrames[7] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\rainyICON\\rainy8.png"));


            windyFrames = new BitmapImage[4];
            windyFrames[0] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\snowyiCON\\windy1.png"));
            
            
            windyFrames[1] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\snowyiCON\\windy2.png"));

            windyFrames[2] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\snowyiCON\\windy1.png"));

            windyFrames[3] = new BitmapImage(new Uri(
                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\IconForWether\\snowyiCON\\windy1.png"));

            
            InitializePetFrames();
            /*
            */
        }

        private async void WeatherLooop()
        {
            var context = new FarmWeatherContext(new SunnyState());

            // Define an infinite loop that changes the weather state every 10 seconds
            while (true)
            {
                // Simulate weather effects
                context.SimulateWeatherEffects();

                // Change weather state
                if (context._state is SunnyState)
                {
                    // Animate sunny weather
                    await AnimateWeather(sunnyFrames);
                    context.TransitionTo(new RainyState());
                }
                else if (context._state is RainyState)
                {
                    // Animate rainy weather
                    await AnimateWeather(rainyFrames);
                    context.TransitionTo(new SnowyState());
                }
                else if(context._state is SnowyState)
                {
                    // Animate snowy weather
                    await AnimateWeather(windyFrames);
                    context.TransitionTo(new SunnyState());
                }

                // Delay for 10 seconds
                await Task.Delay(10000);
            }
        }

        private async Task AnimateWeather(BitmapImage[] frames)
        {
            for (int i = 0; i < 7; i++) // Repeat the animation for 7 seconds
            {
                foreach (var frame in frames)
                {
                    // Update weather image source
                    weatherIcon.Source = frame;

                    // Delay for smooth animation
                    await Task.Delay(200);
                }
            }
        }
        
        
        private async void AnimatePetMovement()
        {
            var buildingsOfType3 = listOfbuildings.Where(building => building.TypeBuilding == 3).ToList();
            int petX = 100; 
            int petY = 100;
            int speed = 2;
            Random random = new Random();
            var baseH = listOfbuildings.Where(building => building.TypeBuilding == 1).ToList();
            int baseX = baseH[0].XBuilding;
            int baseY = baseH[0].YBuilding;

            Console.WriteLine(baseX + " " + baseY + " Type of buidling " + baseH[0].TypeBuilding);



            Console.WriteLine("buildulingType3.Count " + buildingsOfType3.Count);
            while (isPetMoving)
            {
                //Console.WriteLine(@"Uppper loop isPetMoving");
                if (buildingsOfType3.Count > 0)
                {
                    Console.WriteLine(@"buildingsOfType3.Count > 0 - true");
                    
                    
                    int randomIndex = random.Next(0, buildingsOfType3.Count);
                    var targetBuilding = buildingsOfType3[randomIndex];
                    int targetX = targetBuilding.XBuilding;
                    int targetY = targetBuilding.YBuilding;
                    
                    
                    
                    while (petX != targetX || petY != targetY)
                    {
                        petX += worker.SendWorkersToWork(targetX, petX, targetY, petY, 2).x;
                        petY += worker.SendWorkersToWork(targetX, petX, targetY, petY, 2).y;
                        await Application.Current.Dispatcher.InvokeAsync(() =>
                        {
                            Canvas.SetLeft(petImage, petX);
                            Canvas.SetTop(petImage, petY);
                            petImage.Source = petFrames[currentPetFrameIndex];
                        });
                        await Task.Delay(100);
                        if (petX == targetX && petY == targetY)
                        {
                            farmMap.incrementTheZolotoo(5);
                            await Application.Current.Dispatcher.InvokeAsync(() =>
                            {
                                CoinsTextBox.Text = farmMap.amountMoney.ToString();
                            });
                            await Task.Delay(10000);
                            int targetXBase = baseX;
                            int targetYBase = baseY;
                            while (petX != baseX || petY != baseY)
                            {
                                petX += worker.SendWorkersToWork(targetXBase, petX, targetYBase, petY, 4).x;
                                petY += worker.SendWorkersToWork(targetXBase, petX, targetYBase, petY, 4).y;
                                await Application.Current.Dispatcher.InvokeAsync(() =>
                                {
                                    Canvas.SetLeft(petImage, petX);
                                    Canvas.SetTop(petImage, petY);
                                    petImage.Source = petFrames[currentPetFrameIndex];
                                });
                                await Task.Delay(100);
                            }
                            
                            farmMap.incrementTheZolotoo(5);
                            await Application.Current.Dispatcher.InvokeAsync(() =>
                            {
                                CoinsTextBox.Text = farmMap.amountMoney.ToString();
                            });
                        }
                    }
                }

                currentPetFrameIndex = (currentPetFrameIndex + 1) % petFrames.Length;
            }

           
        }


        private void InitializePetFrames()
        {
            // Initialize pet frames
            petFrames = new BitmapImage[7];
            petFrames[0] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\slimeMovement\\pat_frames.png"));
            petFrames[1] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\slimeMovement\\pat_frames1.png"));
            petFrames[2] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\slimeMovement\\pat_frames_2.png"));
            petFrames[3] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\slimeMovement\\pat_frames4.png"));
            petFrames[4] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\slimeMovement\\Screenshot_5.png"));
            petFrames[5] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\slimeMovement\\pat_frames_6.png"));
            petFrames[6] =
                new BitmapImage(new Uri(
                    "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\slimeMovement\\pat_frameslast.png"));
        }


        /// <summary>
        /// Main Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void ModalWindow_ReturnValue(object sender, int value)
        {
            string imagePath = "";
            string personType = "";

            switch (value)
            {
                case 1:
                    imagePath = "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\Gifs\\last knight1.gif";
                    personType = "knight";

                    openSoundPlayer.PlaySound("C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\sword.mp3");

                    break;
                case 2:
                    imagePath =
                        "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\calmImageFolder\\calm1.png";
                    personType = "archer";
                    openSoundPlayer.PlaySound("C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\arrow.mp3");
                    break;
                case 3:
                    imagePath =
                        "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\calmImageFolder\\calm1.png";
                    personType = "sonA";
                    openSoundPlayer.PlaySound("C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\sonAG.mp3");
                    break;
                case 4:
                    imagePath = "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\inviroment\\carrot.png";
                    personType = "carrot";
                    break;
                
                case 5:
                    imagePath = null;
                    personType = "angar";
                    break;
                case 6:
                    imagePath = "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\other\\tractorPNG.png";
                    personType = "tractor";
                    break;
                
                default:
                    MessageBox.Show("Invalid value returned from modal window.");
                    return;
            }



            if (personType == "tractor")
            {
                AddBlock(fox.playerX + 60, fox.playerY, imagePath, 6, personType);
                
            }
            if (personType == "angar")
            {
                
                AddBlock(fox.playerX + 60, fox.playerY, _designer.basic.getDescription(), 5, personType);
            }
            
            if (personType == "carrot")
            {
                AddBlock(fox.playerX + 60, fox.playerY, imagePath, 3, personType);
            }

            if (personType == "archer" || personType == "knight" || personType == "sonA")
            {
                AddBlock(fox.playerX + 60, fox.playerY, imagePath, 2, personType);

                Person clonedPerson = farmMap.registry.GetClone(personType);
                farmMap.peopleDictionary.Add(farmMap.peopleDictionary.Count + 1, clonedPerson);

                Console.WriteLine(clonedPerson.Name + " " + farmMap.peopleDictionary.Count);
                farmMap.addPeople(farmMap.peopleDictionary.Count);
                Console.WriteLine("in farmMap" + farmMap.peopleDictionary.Count);

                ScheduleDeletion(value);
            }
        }


        private void ScheduleDeletion(int value)
        {
            if (difficultyLevelFactory is CasualDifficultyFactory casualFactory)
            {
                casualFactory.ScheduleDeletion(GameCanvas, farmMap.peopleDictionary, farmMap.peopleDictionary.Count,
                    listOfbuildings[farmMap.peopleDictionary.Count].XBuilding,
                    listOfbuildings[farmMap.peopleDictionary.Count].YBuilding);
            }

            if (difficultyLevelFactory is NormalDifficultyFactory normalFactory)
            {
                normalFactory.ScheduleDeletion(GameCanvas, farmMap.peopleDictionary, farmMap.peopleDictionary.Count,
                    listOfbuildings[farmMap.peopleDictionary.Count].XBuilding,
                    listOfbuildings[farmMap.peopleDictionary.Count].YBuilding);
            }
        }

 private void ModalWindow_ReturnValueFromAngar(object sender, bool value)
        {
            string personType = "angar";

            
            if (personType == "angar")
            {
                if (value == true)
                {
                    AddBlock(fox.playerX + 60, fox.playerY, _designer.basicSecond.getDescription(), 5, personType);
                }
            }
           
        }
 
 
 private void ModalWindow_ReturnValueFromTractor(object sender, int value)
 {
     string personType = "tractor";

            
     if (personType == "tractor")
     {
         
         if (_tractor.HasAdditionalComponents())
         {
             Console.WriteLine("The tractor has additional components:");

             List<string> additionalComponentNames = _tractor.GetAdditionalComponentNames();
             
             foreach (string componentName in additionalComponentNames)
             {
                 Console.WriteLine(componentName);
             }
         }
         
         
         if (value == 1)
         {
             
             AddBlock(fox.playerX + 60, fox.playerY, "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\other\\pixil-frame-0.png", 6, personType);
             _tractor.AddComponent(fieldProcessingDevice);
         }

         if (value == 2)
         {
             AddBlock(fox.playerX + 60, fox.playerY, "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\other\\GPSWOrk.png", 6, personType);
             _tractor.AddComponent(navigationPanel);
         }
     }
           
 }


        /// <summary>
        /// Main window
        /// </summary>
        /// <param name="number"></param>
        private void OpenModalWindow(int number)
        {
            if (number == 0)
            {
                ModalWindow modalWindow = new ModalWindow();

                modalWindow.ReturnValue += ModalWindow_ReturnValue;

                modalWindow.Left = this.Left + (this.Width - modalWindow.Width) / 2;
                modalWindow.Top = this.Top + (this.Height - modalWindow.Height) / 2;

                modalWindow.ShowDialog();
            }

            if (number == 5)
            {

                var index = listOfbuildings.FindIndex(u => u.TypeBuilding == 5);

                Console.WriteLine(index + "Hello");
                
                
                angar modalWindow = new angar(farmMap.amountMoney);
                modalWindow.ReturnValue += ModalWindow_ReturnValueFromAngar;
                modalWindow.Left = this.Left + (this.Width - modalWindow.Width) / 2;
                modalWindow.Top = this.Top + (this.Height - modalWindow.Height) / 2;

                modalWindow.ShowDialog();
                
                
            }
            
            
            
            if (number == 6)
            {

                var index = listOfbuildings.FindIndex(u => u.TypeBuilding == 6);

                Console.WriteLine(index + "Hello");
                
                openSoundPlayer.PlaySound("C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\tractor-engine-27641.mp3");
                
                
                tractorMenu modalWindow = new tractorMenu(farmMap.amountMoney);
                modalWindow.ReturnValue += ModalWindow_ReturnValueFromTractor;
                
                
                
                modalWindow.Closed += (sender, args) =>
                {
                    openSoundPlayer.StopSound();
                };
                modalWindow.Left = this.Left + (this.Width - modalWindow.Width) / 2;
                modalWindow.Top = this.Top + (this.Height - modalWindow.Height) / 2;

                modalWindow.ShowDialog();
                
                
            }
            if (number == 1)
            {
                openSoundPlayer.PlaySound("C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\openTrue.mp3");


                Console.WriteLine(@"from the ratusha opening");
                Ratusha modalWindow = new Ratusha(farmMap.amountMoney);


                modalWindow.ReturnValue += CreateBob;

                modalWindow.Closed += (sender, args) =>
                {
                    openSoundPlayer.PlaySound(
                        "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\closeDore.mp3");
                };

                modalWindow.Left = this.Left + (this.Width - modalWindow.Width) / 2;
                modalWindow.Top = this.Top + (this.Height - modalWindow.Height) / 2;

                modalWindow.ShowDialog();
            }
        }

        private void CreateBob(object sender, bool e) 
        {
            if (e == true)
            {
                petImage = new Image
                {
                    Source = petFrames[currentPetFrameIndex],
                    Width = 25,
                    Height = 25
                };

                Canvas.SetLeft(petImage, 100);
                Canvas.SetTop(petImage, 100);

                GameCanvas.Children.Add(petImage);

                Task.Run(() => AnimatePetMovement());
            }
            else
            {
                return;
            }
        }


        /// <summary>
        /// MainWindows
        /// </summary>
        private async void AnimateCoin()
        {
            while (true)
            {
                currentMoneyFrameIndex = (currentMoneyFrameIndex + 1) % moneyFrames.Length;

                moneyIcon.Source = moneyFrames[currentMoneyFrameIndex];

                await Task.Delay(200);
            }
        }

        
        
        /// <summary>
        /// MainForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            var newX = fox.playerX;
            var newY = fox.playerY;

            if (e.Key == Key.W && Keyboard.IsKeyDown(Key.A))
            {
                newX -= fox.PlayerSpeed;
                newY -= fox.PlayerSpeed;
                fox.flipTransform.ScaleX = -1;
            }
            else if (e.Key == Key.W && Keyboard.IsKeyDown(Key.D))
            {
                newX += fox.PlayerSpeed;
                newY -= fox.PlayerSpeed;
                fox.flipTransform.ScaleX = 1;
            }
            else if (e.Key == Key.S && Keyboard.IsKeyDown(Key.A))
            {
                newX -= fox.PlayerSpeed;
                newY += fox.PlayerSpeed;
                fox.flipTransform.ScaleX = -1;
            }
            else if (e.Key == Key.S && Keyboard.IsKeyDown(Key.D))
            {
                newX += fox.PlayerSpeed;
                newY += fox.PlayerSpeed;
                fox.flipTransform.ScaleX = 1;
            }
            else
            {
                switch (e.Key)
                {
                    case Key.W:
                        newY -= fox.PlayerSpeed;
                        break;
                    case Key.S:
                        newY += fox.PlayerSpeed;
                        break;
                    case Key.A:
                        newX -= fox.PlayerSpeed;
                        fox.flipTransform.ScaleX = -1;
                        break;
                    case Key.D:
                        newX += fox.PlayerSpeed;
                        fox.flipTransform.ScaleX = 1;
                        break;
                    case Key.E:
                        if (IsPlayerNearObject(fox.playerX, fox.playerY).IsNear == false)
                            OpenModalWindow(0);
                        else
                            OpenModalWindow(IsPlayerNearObject(fox.playerX, fox.playerY).typeB);
                        
                        break;
                    case Key.P:
                        if (IsPlayerNearObject(fox.playerX, fox.playerY).IsNear == false)
                        {
                        }

                        if (IsPlayerNearObject(fox.playerX, fox.playerY).typeB == 2)
                        {
                            string enemyNeed = IsPlayerNearObject(fox.playerX, fox.playerY).name;

                            punchTheEnemy(enemyNeed);
                        }

                        if (IsPlayerNearObject(fox.playerX, fox.playerY).typeB == 3)
                        {
                        }

                        break;
                    case Key.H:
                        if (!isFarmCreated)
                        {
                            openSoundPlayer.PlaySound(
                                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\buildingSound.mp3");


                            CoinsTextBox.Text = farmMap.getAmountOfMoney().ToString();
                            farmMap.registry.AddPrototype("knight",
                                new KnightConcreate("Sir Lancelot", "Sword Fighting"));
                            farmMap.registry.AddPrototype("archer", new ArcherConcreate("Robin Hood", 1000));
                            farmMap.registry.AddPrototype("sonA", new SonOfAnarchy("Monster", "World destroyer"));

                            AddBlock(fox.playerX + 60,
                                fox.playerY,
                                "C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\inviroment\\houseGPED.png",
                                1,
                                "Ratusha");

                            // Позначте, що ферма була створена
                            isFarmCreated = true;
                        }
                        else
                        {
                            MessageBox.Show("The farm already created");
                        }
                        break;
                    case Key.J:
                       
                        
                        
                        IBuilding basicPizza2 = new PlainBuilding.buildingLever3(new PlainBuilding.BuildingLevelTwo((new PlainBuilding())));
		
                        Console.WriteLine("Ingredients: " + basicPizza2.getDescription());
		
                        Console.WriteLine("Price: " + basicPizza2.getCost());
                        
                        break;
                }
            }

            if (IsMoveValid(newX, newY))
            {
                fox.playerX = newX;
                fox.playerY = newY;

                AnimatePlayer(fox.player, fox.playerX, fox.playerY);
            }
        }


        private async Task PunchAnimation()
        {
            fox.player.Source =
                new BitmapImage(
                    new Uri("C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\foxFirghterFrame1.png"));


            fox.player.Source = fox.animationFrames[fox.currentFrameIndex];
        }

        private void punchTheEnemy(string enemyName)
        {
            Console.WriteLine("Punch");
            PunchAnimation();

            openSoundPlayer.PlaySound("C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\punch.mp3");


            if (enemyName == "knight")
            {
                openSoundPlayer.PlaySound("C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\punch.mp3");

                farmMap.incrementTheZolotoo(2);
            }
            else if (enemyName == "archer")
            {
                openSoundPlayer.PlaySound("C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\punch.mp3");

                farmMap.incrementTheZolotoo(5);
            }
            else if (enemyName == "sonA")
            {
                openSoundPlayer.PlaySound("C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\punch.mp3");

                farmMap.incrementTheZolotoo(5);
            }

            int currentCoins = farmMap.getAmountOfMoney();

            CoinsTextBox.Text = currentCoins.ToString();
            PunchAnimation();
        }

        private bool IsMoveValid(double x, double y)
        {
            return x >= 0 && x <= GameCanvas.ActualWidth && y >= 0 && y <= GameCanvas.ActualHeight;
        }


        private (bool IsNear, int typeB, string name) IsPlayerNearObject(double x, double y)
        {
            bool isNear = false;
            int bNumber = 0;
            string name = null;

            Console.WriteLine("Coordinate of player: " + x + " " + y);
            foreach (var building in listOfbuildings)
            {
                double buildingX = building.XBuilding;
                double buildingY = building.YBuilding;

                double distance = Math.Sqrt(Math.Pow(x - buildingX, 2) + Math.Pow(y - buildingY, 2));

                Console.WriteLine("Distance" + distance);
                if (distance < 80)
                {
                    bNumber = building.TypeBuilding;
                    isNear = true;
                    name = building.nameOfEnemy;
                }
            }

            return (isNear, bNumber, name);
        }

        private void AnimatePlayer(UIElement element, double toX, double toY)
        {
            DoubleAnimation animationX = new DoubleAnimation(toX, TimeSpan.FromSeconds(0.2));
            DoubleAnimation animationY = new DoubleAnimation(toY, TimeSpan.FromSeconds(0.2));
            element.BeginAnimation(Canvas.LeftProperty, animationX);
            element.BeginAnimation(Canvas.TopProperty, animationY);

            fox.currentFrameIndex = (fox.currentFrameIndex + 1) % fox.animationFrames.Length;
            fox.player.Source = fox.animationFrames[fox.currentFrameIndex];
        }

        private void AddBlock(double x, double y, string path, int type, string name)
        {
            GameCanvas.Children.Remove(fox.player);
            Image block = new Image
            {
                Width = 100,
                Height = 100,
                Source = new BitmapImage(new Uri(path))
            };

            double blockX;
            if (fox.flipTransform.ScaleX == -1)
            {
                blockX = x - 100;
            }
            else
            {
                blockX = x;
            }


            int centerX = (int)(blockX + block.Width / 2);
            int centerY = (int)(y + block.Height / 2);

            var tractroList = listOfbuildings.Where(u => u.TypeBuilding == 6).ToList();

            
            if (tractroList.Any() && type == 6)
            {
                
                var index = listOfbuildings.FindIndex(u => u.TypeBuilding == 6);

                centerX = listOfbuildings[index].XBuilding;
                centerY = listOfbuildings[index].YBuilding;
                listOfbuildings[index].Improved = true;
                
                
                Canvas.SetLeft(block, centerX - 50);
                Canvas.SetTop(block, centerY - 50);
                
                GameCanvas.Children.Add(block);

                GameCanvas.Children.Add(fox.player);

                return;
            }
            var buildingAnhar = listOfbuildings.Where(u => u.TypeBuilding == 5).ToList();

            if (buildingAnhar.Any() && type == 5)
            {
                openSoundPlayer.PlaySound("C:\\Users\\Kostya\\Desktop\\WpfApplication2\\WpfApplication2\\game-level-complete-143022.mp3");
                var index = listOfbuildings.FindIndex(u => u.TypeBuilding == 5);

                centerX = listOfbuildings[index].XBuilding;
                centerY = listOfbuildings[index].YBuilding;
                listOfbuildings[index].Improved = true;
                
                
                Canvas.SetLeft(block, centerX - 50);
                Canvas.SetTop(block, centerY - 50);
                
                GameCanvas.Children.Add(block);

                GameCanvas.Children.Add(fox.player);
                
                
            }
            else
            {
                listOfbuildings.Add(new PointsOfBuilding(centerY, centerX, type, name));
                Canvas.SetLeft(block, blockX);
                Canvas.SetTop(block, y);

                GameCanvas.Children.Add(block);

                GameCanvas.Children.Add(fox.player);
            }
        }
    }
}
