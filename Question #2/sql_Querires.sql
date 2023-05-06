-- --using dataset of this website to test: https://www.programiz.com/sql/online-compiler/
  
-- --website code test
--SELECT Cust.first_name, COUNT(Orders.customer_id), SUM(Orders.amount)
--FROM Customers AS Cust
--INNER JOIN Orders ON Orders.customer_id = Cust.customer_id
--GROUP BY Orders.customer_id
--HAVING COUNT(Orders.customer_id) > 1 AND SUM(Orders.amount) > 500;


-- --Question 2 answer
SELECT Cust.name, Cust.email
FROM customers AS Cust
INNER JOIN orders ON orders.customer_id = Cust.customer_id
GROUP BY orders.customer_id
HAVING COUNT(orders.customer_id) > 1 AND SUM(orders.total) > 1000;
