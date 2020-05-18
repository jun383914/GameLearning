# C# RPG GameLearning

---
This is a C# learning project I found online at https://scottlilly.com/build-a-cwpf-rpg/ 

I followed the tutorial and learned as much as I can. 

The code was posted here for me to get familiar with how to use github, and as a resouce for my future study.

---

## Concept Implemented:

* MVC Concept (stands for Model-View-Controller)
* How each elements relating to each other
* Having each elements interact with each other and display in the user interface

---

## Notes
### Lesson 03.1
* Introduced basic XAML(stands for Extensible Application Markup Language) operations.
* When you have an open tag, you need a corresponding closing tag by </> (if no contect is in between two tags)or </nameplaceholder>.
* Grid.RowDefinitions: Auto means to adjust based on the size of the content; * means take much space as you can; numbers means pixels it can use.
* Grid.ColumnSpan: define that how many columns you need this class to take.
### Lesson 03.2
* Use repository to track changes and reverse changes if needed.
---
### Lesson 03.3
* Start with designing games, based on what Nouns project has, create class to reprensent "things" in the game. Those classes will be Models in the game.
* Place Model classes in a sepeate project(project type will be class library) under solution, this will make later auotomated testing easier.
* Analyze what information do you want these "things"(or business object) to hold, what data type will it be? Then place it in the Model class as property so you can control the accessibility of it. 
---
### Lesson 03.4
* How do we reflect changes in players class onto UI? We can create player object in views but this can be hard for us to create automated test later on. Also, if the project becomes larger, this will cause issues as well. 
* A better way to serve as a middleman(also called Controllers or Presenter) between view and models is something called "ViewModels". I will create players class object here. The name of class is GameSession.
* Also, constructor was introduced here. It's not mandatory to write constructor out, but if you want speicial thing of the object when it was initialized, then you want to write it out with your own specific requirement. 
* Make sure to double check class propery accessibilty and include using statement to add reference if necessary.
* In ViewModels, I create Player CurrentPlayer property to hold player object.
```
  Player CurrentPlayer{get;set;}
```
---
### Lesson 03.5
* To let UI project work with class in Engine project, I need to add reference to Engine project which can be done via rightclick reference under UI project to add reference.
* For views to work with viewmodels, I will need to let cs file under UI knows what to work with, and that is by creating a private viewmodel variable(_gamesession).
* Code below is using DataContext to let UI cs file know what object UI is working with.
```
  DataContext=_gameSession;
```
* I use label inside Grid to define specific contents for rows and colomns; 
```
  Content="Name:"
```
  simply display the content.
```
  Content="{Binding CurrentPlayer.Name}"
```
  This is how I bind property of currentplayer to be displayed in the UI.

---
### Lesson 03.6
* Use eventhandlers to update UI if object propery was changed.
* Built-in Interface INotifyProperyChanged can help with it. Here is the implementation of the interface:
```
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
```
* Also, Aoto property now needs to be more specific and I need to write out the backing variable.
* This pattern is specific called: Publish and Subscribe design pattern. "Player model object is publishing some info/event and UI is subscribing the event and will update UI"
---
## Game Map
![alt text](https://github.com/jun383914/GameLearning/blob/master/WPFGameWorld.png)
