USE MvcMovieContext;

CREATE TABLE Movie
(Id INT AUTO_INCREMENT PRIMARY KEY,
Title VARCHAR(20),
ReleaseDate DATE,
Genre VARCHAR(20),
Price DECIMAL(6,2));

INSERT INTO Movie (Id, Title, ReleaseDate, Genre, Price)
VALUES
(1, 'When Harry Met Sally', '1989-02-12', 'Romantic Comedy', 7.99),
(2, 'Ghostbuster', '1984-03-13', 'Thriller', 8.99);