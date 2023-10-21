# **LIVRE LAND**

## Bonjour et bienvenue sur le dépôt du projet LIVRE LAND ! 👋

*******

### Sommaire 
 1. [Accessibilité](#acces)
 2. [Progression](#progression)
 3. [Présentation du projet](#presentation)
 4. [Architecture](#architecture)
 5. [Contenu](#contenu)
 6. [Auteurs](#auteurs)

*******

<div id='acces'/> 

Pour accéder au code de l'application, vous pouvez cloner la branche `master` du dépôt Code#0 et ouvrir celle-ci dans `Microsoft Visual Studio` par exemple.    
  
Disponible sur :    
![](https://img.shields.io/badge/Android-3DDC84?style=for-the-badge&logo=android&logoColor=white)
![](https://img.shields.io/badge/iOS-000000?style=for-the-badge&logo=ios&logoColor=white)  
  
> **Warning**: L'application est fonctionnelle sous Windows et Android mais n'a pas été testée sous IOS.   

*******

<div id='progression'/>

## 🚧  __EN PROGRESSION__

### Étape 1 : Développement des vues en XAML  
- Intégralité des pages proposées sur la page d'accueil développées
- Mode clair & Mode sombre disponibles (pas très esthétique)
- Utilisable en mode portrait ou mode paysage  
- Exploitation des Styles et des Content View réutilisables  
- Mise à disposition de quelques données dans un Stub pour la présentation des vues  
- View Model non utilisés et fonctionnalités pas toutes mises en place (seulement les vues)
- Navigation généralement utilisable mais pas parfaitement codée  

---

### Étape 2 : Personnal MVVM Toolkit

La création de ce `Toolkit Personnel` a pour but de faciliter le développement de l'application en fournissant un ensemble de fonctionnalités et de composants réutilisables. De plus, à l'aide d'une classe comme `RelayCommand`, notre objectif est de ne pas inclure dans nos ViewModels une dépendance avec les Commands de .NET MAUI.  
  
Nous pouvons représenter la structure de notre toolkit avec le diagramme suivant :  

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
RelayCommand ..|> ICommand
```
  
Cette strcuture est une version remplaçant pour le moment le `Community Toolkit` mis en place par Microsoft qui permet aussi de supprimer beaucoup de code inutile en remplaçant celui-ci par des annotations et des classes partielles.  

---

### Étape 3 : MVVM  

Nous utilisons au sein de notre projet le **patron d'architecture MVVM** avec les ViewModels Wrapping et Applicatives.  
  
Nous retrouvons donc les 3 grandes parties du patron :  
  
- **Model** :  
Le `Model` représente la `logique métier`. Il est écrit en `C#` et est adpaté pour diifférentes applications.  
  
- **View** :  
Les `Vues` sont écrites en `XAML` et représentent l'interface utilisateur avec les vues de l'application. Le `Data Binding` est utilisé entre les propriétés du XAML et celles des ViewModels. Enfin, des évènements sont déclenchés à partir de certains composants des vues.
  
- **ViewModel** :
Les `ViewModels` sont écrits en `C#` et sont divisables en deux grandes catégories :  
    * Les **Wrapping ViewModel** encapsulent les données du modèle et exposent des propriétés et des commandes nécessaires à la vue pour interagir avec le modèle.   
    * Les **Applicative ViewModel** peuvent inclure une logique métier spécifique et des propriétés calculées, elles peuvent également exposer des commandes pour effectuer des actions spécifiques liées à la vue.  
  
Le schéma suivant montre bien les relations entre les grandes parties du `patron MVVM` :  
  
![Schema_MVVM](documentation/schema_mvvm.png)
 
Le **diagramme de classes** pouvant être extrèmement grand à cause des multiples classes au sein de notre projet, j'ai décidé de représenter une partie de celui-ci qui pourrait se répéter pour toutes les autres parties. L'objectif principal étant de comprendre comment fonctionne le **modèle MVVM** et comment les classes intéragissent entre elles, j'ai choisi de faire mon exemple avec la partie des livres qui est la plus générale du sujet.  

*******

<div id='presentation'/>

## **Présentation**

LivreLand : votre bibliothèque connectée !  
Retrouver tous vos livres préférés en un clic.  

*******

<div id='contenu'/>

## Fonctionnalités

**TP2 - Base** : 
- [x] Page d'accueil  
- [x] Affichage des livres de l'utilisateur : afficher tous les livres de l'utilisateur dans la vue BooksPage et permettre la sélection d'un livre et la navigation vers la page BookPage  
    * seule la note n'est pas encore affichée sous la forme d'étoiles
- [x] Filtrage par auteur et par date de publication : afficher dans la vue de filtrage (FilterPage)  
  
**TP2 - Ajouts** :  
- [x] Changer le statut de lecture d'un livre
    * la mise à jour du statut de livre se fait si l'on recharge les livres en revenant sur la BooksPage, cependant elle ne se fait pas encore directement sur la page de détails pour le moment
- [x] Ajouter un livre aux favoris  
    * l'ajout en favoris fonctionne, cependant lorque je choisis à partir de la page BooksPage d'ajouter un livre qui ne se trouve pas sur la première page alors celui-ci supprime souvent tous les livres déjà en favoris
- [x] Filtrer les livres par Auteur, Date de publication, Note 
    * le filtrage fonctionne, au deuxième clique sur une date par exemple une fois une première date visitée, je remarque des soucis avec de temps à autre une exception
- [x] Ajouter un livre à sa collection en saisissant l'ISBN
- [x] Supprimer un livre  
- [x] Prêter un livre (et ajouter un contact si besoin)  
    * la page avec les contacts n'est pas esthétiquement très réussie
- [x] Consulter la liste des livres prêtés
    * j'ai fait le choix de n'afficher que les livres _actuellement_ prêtés ou empruntés
  
**TP3** :
- [ ] Modifier l'intégralité du code pour que l'application utilise désormais le MVVM Community Toolkit à la place du toolkit personnel
  
**TP 4** :  
Ajouter les vues et les VM nécessaires pour permettre :  
- [x] Le scan de code-barres afin d'ajouter de nouveaux livres  
    * le scan de code-barres fonctionne mais le livre n'est pas encore directement ajouté dans la liste
- [ ] La recherche en ligne (via le web service)  

*******

<div id='architecture'/>

## Architectures du modèle et des services fournises

Dans cette partie, vous retrouverez dans un premier temps deux diagrammes mis à disposition dans le sujet représentant d'abord le `Modèle` puis les `Services et Interfaces` :   

### Modèle
```mermaid
classDiagram
direction LR
class Book {
    +Id : string
    +Title : string
    +Publishers : List~string~
    +PublishDate : DateTime
    +ISBN13 : string
    +Series : List~string~
    +NbPages : int
    +Format : string
    +ImageSmall : string
    +ImageMedium : string
    +ImageLarge : string
}

class Languages {
    <<enum>>
    Unknown,
    French,
}

class Work {
    +Id : string
    +Description : string
    +Title : string
    +Subjects : List~string~
}

class Contributor {
    +Name : string
    +Role : string
}

class Author {
    +Id : string
    +Name : string
    +ImageSmall : string
    +ImageMedium : string
    +ImageLarge : string
    +Bio : string
    +AlternateNames : List~string~
    +BirthDate : DateTime?
    +DeathDate : DateTime?
}

class Link {
    +Title : string
    +Url : string
}

class Ratings {
    +Average : float
    +Count : int
}

Book --> "1" Languages  : Language
Book --> "*" Contributor : Contributors
Author --> "*" Link : Links
Work --> "*" Author : Authors
Work --> "1" Ratings : Ratings
Book --> "*" Author : Authors
Book --> "*" Work : Works

class Status {
    <<enum>>
    Unknown,
    Finished,
    Reading,
    NotRead,
    ToBeRead
}

class Contact{
    +string Id;
    +string FirstName;
    +string LastName;
}
```  

---

### Services et Interfaces

```mermaid
classDiagram
direction LR
Book --> "1" Languages  : Language
Book --> "*" Contributor : Contributors
Author --> "*" Link : Links
Work --> "1" Ratings : Ratings
Work --> "*" Author : Authors
Book --> "*" Work : Works
Book --> "*" Author : Authors

class IUserLibraryManager {
    <<interface>>
    +AddBook(Book book) : Task<Book>
    +AddBook(string id) : Task<Book>
    +AddBookByIsbn(string isbn) : Task<Book>
    +RemoveBook(Book book) : Task<bool>
    +RemoveBook(string id) : Task<bool>
    +RemoveBook(string id) : Task<bool>
    +AddToFavorites(Book book) : Task<bool>
    +AddToFavorites(string bookId) : Task<bool>
    +RemoveFromFavorites(Book book) : Task<bool>
    +RemoveFromFavorites(string bookId) : Task<bool>
    +UpdateBook(Book updatedBook) : Task<Book>
    +AddContact(Contact contact) : Task<Contact>
    +RemoveContact(Contact contact) : Task<bool>
    +LendBook(Book book, Contact contact, DateTime? loanDate) : Task<bool>
    +GetBackBook(Book book, DateTime? returnedDate) : Task<bool>
    +BorrowBook(Book book, Contact owner, DateTime? borrowedDate) : Task<bool>
    +GiveBackBook(Book book, DateTime? returnedDate) : Task<bool>

    +GetCurrentLoans(int index, int count)
    +GetPastLoans(int index, int count)
    +GetCurrentBorrowings(int index, int count)
    +GetPastBorrowings(int index, int count)
    +GetContacts(int index, int count)
}

class ILibraryManager {
    <<interface>>
    +GetBookById(string id)
    +GetBookByIsbn(string isbn)
    +GetBooksByTitle(string title, int index, int count, string sort)
    +GetBooksByAuthorId(string authorId, int index, int count, string sort)
    +GetBooksByAuthor(string author, int index, int count, string sort)
    +GetAuthorById(string id)
    +GetAuthorsByName(string substring, int index, int count, string sort)
}

class Status {
    <<enum>>
}

IUserLibraryManager ..|> ILibraryManager
IUserLibraryManager ..> Status
IUserLibraryManager ..> Contact
IUserLibraryManager ..> Book
ILibraryManager ..> Book
ILibraryManager ..> Author
```

*******

## Ressources

- Temps
    - 4 Septembre au 22 Octobre 2023   
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
