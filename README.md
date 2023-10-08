# **LIVRE LAND**

## Bonjour et bienvenue sur le dépôt du projet LIVRE LAND ! 👋

*******

Sommaire 
 1. [Accessibilité](#acces)
 2. [Progression](#progression)
 3. [Présentation du projet](#presentation)
 4. [Contenu](#contenu)
 5. [Auteurs](#auteurs)

*******

<div id='acces'/> 

Pour accéder au code de l'application, vous pouvez cloner la branche `master` du dépôt Code#0 et ouvrir celle-ci dans `Microsoft Visual Studio` par exemple.   

> **Warning**: Le déploiement n'a pas encore été fait.  

Disponible sur :  
![](https://img.shields.io/badge/Android-3DDC84?style=for-the-badge&logo=android&logoColor=white)
![](https://img.shields.io/badge/iOS-000000?style=for-the-badge&logo=ios&logoColor=white)

*******

<div id='progression'/>

🚧  __EN PROGRESSION__

Étape 1 : Développement des vues en XAML  
- Intégralité des pages proposées sur la page d'accueil développées
- Mode clair & Mode sombre disponibles (pas très esthétique)
- Utilisable en mode portrait ou mode paysage  
- Exploitation des Styles et des Content View réutilisables  
- Mise à disposition de quelques données dans un Stub pour la présentation des vues  
- View Model non utilisés et fonctionnalités pas toutes mises en place (seulement les vues)
- Navigation généralement utilisable mais pas parfaitement codée  

---

Étape 2 : Personnal MVVM Toolkit

```mermaid
classDiagram
direction LR
class INotifyPropertyChanged {
    <<interface>>
}

class ObservableObject{
    +PropertyChanged: event PropertyChangedEventHandler?;
    #OnPropertyChanged (string PropertyName = null) : void
    #SetProperty<T> (T member, T value, Action<T> action, string propertyName = null) : void
    #SetProperty<T> (ref T member, T value, string propertyName = null) : void
}

class BaseViewModel{
    +Model: TModel;
    -model: TModel;
    +BaseViewModel(TModel model)
    +BaseViewModel() : this(default)
}

class ICommand{
    <<interface>>
}

class RelayCommand{
    +CanExecuteChanged: event EventHandler?;
    +CanExecute (object? parameter) : bool
    +Execute (object? parameter) : void
    +RefreshCommand() : void
} 

ObservableObject ..|> INotifyPropertyChanged
BaseViewModel --|> ObservableObject
BaseViewModel --|> ObservableObject
RelayCommand ..|> ICommand

```

*******

<div id='presentation'/>

### **Présentation**

LivreLand : votre bibliothèque connectée !  
Retrouver tous vos livres préférés en un clic.  

*******

<div id='contenu'/>

## Fonctionnalités

- Livres triés par auteur, date, notes, statut de lecture...
- Livres à lire plus tard
- Livres prêtés
- Livres favoris

*******

## Ressources

- Temps
    - 4 Septembre au   
- Matériel
    - Ordinateurs portables sous Windows   
    - Émulateur sous Visual Studio 2022
    - Téléphone portable    
- Langages utilisés
    -  ![](https://img.shields.io/badge/.NETMAUI-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
    -  ![](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
    -  ![](https://img.shields.io/static/v1?style=for-the-badge&message=XAML&color=0C54C2&logo=XAML&logoColor=FFFFFF&label=)
- Personnes 
    - 1 étudiant en BUT Informatique


*******

<div id='auteurs'/>

## Auteur

Étudiant 3ème Annnée - BUT Informatique - IUT Clermont Auvergne - 2023-2024   
`BRODA Lou`
