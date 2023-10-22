# **LIVRE LAND**

## Bonjour et bienvenue sur le dépôt du projet LIVRE LAND ! 👋

*******

### README réservé à l'Implémentation du MVVM Community Toolkit 

J'ai essayé d'implémenter au sein de cette branche le `MVVM Community Toolkit` dans mon projet.  
  
Il s'agit d'une bibliothèque open source conçue pour faciliter le développement d'applications en utilisant l'architecture MVVM (Modèle-Vue-VueModèle) dans le contexte de .NET MAUI. Le MVVM Community Toolkit offre un ensemble de classes et de fonctionnalités qui simplifient la mise en œuvre du modèle MVVM dans les applications .NET MAUI. Il propose des utilitaires pour la gestion de la liaison de données, la navigation entre les pages, la gestion des dialogues, la validation des données et bien d'autres fonctionnalités essentielles pour un développement efficace. Grâce à cette bibliothèque, il est possible d'accélérer le processus de création d'applications multiplateformes robustes et maintenables dans .NET MAUI en adoptant les bonnes pratiques de l'architecture MVVM.    
  
Parmi les éléments à connaître du toolkit que j'ai pu utiliser, nous retrouvons :
- **[ObservableObject]** -> utilisable avant une classe partielle  
  
- **[ObservableProperty]** -> utilisable devant le field afin de générer automatique la propriété associée  
- **[NotifyPropertyChangedFor(nameof(Propriété))]** -> permet de faire comme un `OnPropertyChanged` suite à la modification d'une propriété  
- **[NotifyCanExecuteChangedFor(nameof(Commande))]** -> permet également de notifier une propriété d'un changement lié à une commande  
Il existe d'autres possibilités liées aux propriétés comme la validation des données que je n'ai pas réellement utilisées.  
  
- **[RelayCommand]** -> permet de générer une commande à partir d'une méthode (les attributs sont pris en compte automatiquement tout comme l'Asynchronisme si la méthode à pour type de retour `Async Task`)  
- **[RelayCommand(CanExecute = nameof(Propriété))]** -> Activation/Désactivation des commandes en fonction d'une propriété  
- **[NotifyCanExecuteChangedFor(nameof(Commande))]** -> Propriété pouvant subir des changements au sein d'une méthode  
Ici encore, il existe d'autres annotations pour gérer par exemple les exceptions liées à l'asynchronisme ou pour annuler des commandes que je n'ai pas eu l'utilité.  

*******

### Mise en place

Je pense avoir plutôt bien compris le fonctionnement de ce Toolkit malgré le peu de temps en ma possession ayant fait le TP4 avant celui-ci. 
Je ne suis pas sûr d'avoir pu exploiter toutes les capacités du toolkit mais j'ai abordé les principales ressources de l'outil. J'ai réussi à obtenir une version semblable à celle que j'ai sur ma branche master.

> *Warning* : Les dernières fonctionnalités développées sur la branche master ne sont pas disponibles sur cette branche.

*******

### Auteur

Étudiant 3ème Annnée - BUT Informatique - IUT Clermont Auvergne - 2023-2024   
`BRODA Lou`
