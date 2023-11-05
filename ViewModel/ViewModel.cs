using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using WpfApp1.Model;
using System.Windows.Data;
using System.Windows;
using static System.Reflection.Metadata.BlobBuilder;
using System;

namespace WpfApp1.ViewModel
{
    internal class ApplicationViewModel : INotifyPropertyChanged
    {
        private Book selectedBook;
        private User selectedUser;
        private Loan selectedLoan;
        public ObservableCollection<Book> books { get; set; }
        public ObservableCollection<User> users { get; set; }
        public ObservableCollection<Loan> loans { get; set; }
        // команда добавления нового объекта
        private RelayCommand issueBook;
        public RelayCommand IssueBook
        {
            get
            {
                return issueBook ??
                  (issueBook = new RelayCommand(obj =>
                  {
                      if (selectedUser != null && selectedBook != null && selectedBook.Count > 0)
                      {
                          Loan newLoan = new Loan(selectedUser, selectedBook);
                          loans.Add(newLoan);

                          selectedBook.Count--;

                          CollectionViewSource.GetDefaultView(books).Refresh();
                      }
                      else
                      {
                          MessageBox.Show("Выберите пользователя и доступную книгу для выдачи.");
                      }
                  }));
            }
        }
        private RelayCommand returnBook;
        public RelayCommand ReturnBook
        {
            get
            {
                return returnBook ??
                  (returnBook = new RelayCommand(obj =>
                  {
                      {
                          if (selectedLoan != null)
                          {
                              selectedLoan.Book.Count++;

                              loans.Remove(selectedLoan);

                              CollectionViewSource.GetDefaultView(books).Refresh();
                          }
                          else
                          {
                              MessageBox.Show("Выберите книгу для возврата.");
                          }
                      }
                  }));
            }
        }
        private string name1;
        public string Name1 { 
            get { return name1; } 
            set { name1 = value; OnPropertyChanged(Name1); }
        }
        private string family1;
        public string Family1
        {
            get { return family1; }
            set { family1 = value; OnPropertyChanged(Family1); }
        }
        private RelayCommand addUser;
        public RelayCommand AddUser
        {
            get
            {
                return addUser ??
                  (addUser = new RelayCommand(obj =>
                  {
                      
                      if (!string.IsNullOrEmpty(Name1) && !string.IsNullOrEmpty(Family1))
                      {
                          User newUser = new User(users.Count + 1, name1, family1);
                          users.Add(newUser);
                          Name1 = "";
                          Family1 = "";
                          //userNameTextBox.Clear();
                          //userFamilyTextBox.Clear();
                      }
                      else
                      {
                          MessageBox.Show("Пожалуйста, введите имя и фамилию пользователя.");
                      }
                  }));
            }
        }

        private string search1;
        public string Search1
        {
            get { return search1; }
            set { search1 = value; OnPropertyChanged(Search1); }
        }
        private RelayCommand searchUser;
        public RelayCommand SearchUser
        {
            get
            {
                return searchUser ??
                  (searchUser = new RelayCommand(obj =>
                  {
                      {

                          if (string.IsNullOrEmpty(search1))
                          {
                              MessageBox.Show("Пожалуйста, введите имя или фамилию пользователя для поиска.");
                              return;
                          }

                          SelectedUser = null;

                          foreach (User user in users)
                          {
                              if (user.Name.Contains(search1, StringComparison.OrdinalIgnoreCase) ||
                                  user.Family.Contains(search1, StringComparison.OrdinalIgnoreCase))
                              {
                                  SelectedUser = user;
                                  break;
                              }
                          }

                          if (SelectedUser == null)
                          {
                              MessageBox.Show("Пользователь не найден.");
                          }
                      }
                  }));
            }
        }

        private string book1;
        public string Book1
        {
            get { return book1; }
            set { book1 = value; OnPropertyChanged(Book1); }
        }
        private RelayCommand searchBook;
        public RelayCommand SearchBook
        {
            get
            {
                return searchBook ??
                  (searchBook = new RelayCommand(obj =>
                  {
                      {

                          if (string.IsNullOrEmpty(book1))
                          {
                              MessageBox.Show("Пожалуйста, введите название книги или автора для поиска.");
                              return;
                          }

                          SelectedBook = null;

                          foreach (Book book in books)
                          {
                              if (book.Title.Contains(book1, StringComparison.OrdinalIgnoreCase) ||
                                  book.Author.Contains(book1, StringComparison.OrdinalIgnoreCase))
                              {
                                  SelectedBook = book;
                                  break;
                              }
                          }

                          if (SelectedBook == null)
                          {
                              MessageBox.Show("Книга не найдена.");
                          }
                      }
                  }));
            }
        }

        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public Loan SelectedLoan
        {
            get { return selectedLoan; }
            set
            {
                selectedLoan = value;
                OnPropertyChanged("SelectedLoan");
            }
        }
        public ApplicationViewModel()
        {
            users = new() {
                new User(1, "Тамерлан", "Сырат"),
                new User(2, "Глеб", "Гааг"),
                new User(3, "Анастасия", "Иванова"),
                new User(4, "Андрей", "Воркунов"),
                new User(5, "Полина", "Красных"),
                new User(6, "Дмитрий", "Емельянов"),
                new User(7, "Григорий", "Белявцев"),
                new User(8, "Александр", "Монич"),
            };
            books = new() {
                new Book("Блэкаут", "Александр Левченко", DateTime.Now, 3),
                new Book("Жизнь на продажу", "Юкио Мисима", DateTime.Now, 4),
                new Book("1984", "Джордж Оруэлл", DateTime.Now, 4),
                new Book("Преступление и наказание", "Фёдор Достоевский", DateTime.Now, 7),
                new Book("Мартин Иден", "Джек Лондон", DateTime.Now, 2),
                new Book("Маленький принц", "Антуан де Сент-Экзюпери", DateTime.Now, 1),
                new Book("Мастер и Маргарита", "Михаил Булгкаов", DateTime.Now, 8),
                new Book("Отцы и дети", "Иван Тургенев", DateTime.Now, 22),
            };
            loans = new() {
                new Loan (users[0], books[0])
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}