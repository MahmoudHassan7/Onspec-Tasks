SELECT Customers.[name]
      ,Customers.[email]
  FROM [testdb].[dbo].[Customers]
  INNER JOIN [testdb].[dbo].[Orders]
  ON Customers.[id] = Orders.[customer_id]
  GROUP BY Customers.[name]
        ,Customers.[email]
  HAVING COUNT(Orders.[id]) >= 2 AND SUM(Orders.[total]) > 1000; 
