CREATE TABLE Customers (
    id int,
    name varchar(255),
    email varchar(255),
    PRIMARY KEY (ID)
);

INSERT INTO Customers (id, name, email)
VALUES 
(1, 'Tom', 'Tom@gmail.com'),
(2, 'casy', 'casy@gmail.com'),
(3, 'kathrin', 'kathrin@gmail.com'),
(4, 'lux', 'lux@gmail.com'),
(5, 'rio', 'rio@gmail.com');

CREATE TABLE Orders (
    id int,
    customer_id int,
    total float,
    order_date date
    PRIMARY KEY (id),
    FOREIGN KEY (customer_id) REFERENCES Customers(id)
);

INSERT INTO Orders (id, customer_id, total, order_date)
VALUES 
(1, 1, 300, '12/2/2023'),
(2, 1, 100, '12/2/2023'),
(3, 1, 600, '12/2/2023'),
(4, 2, 11, '12/2/2023'),
(5, 2, 10, '12/2/2023'),
(6, 2, 50, '12/2/2023'),
(7, 2, 100, '12/2/2023'),
(8, 3, 500, '12/2/2023'),
(9, 3, 650, '12/2/2023'),
(10, 4, 500, '12/2/2023'),
(11, 4, 300, '12/2/2023'),
(12, 4, 300, '12/2/2023'),
(13, 5, 500, '12/2/2023'),
(14, 5, 500, '12/2/2023');