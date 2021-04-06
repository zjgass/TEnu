USE final_capstone
GO

declare @json  nvarchar(4000);
set @json = N'{"ingredients":
	[{"name": "bananas", "qty": "6ea"}, {"name": "flour", "qty": "4cups"}, {"name": "butter", "qty": "1stick"}]}';

select recipe_name
from recipe
where JSON_Query(ingredients, '$') like '%banana%'

SELECT ingredient_list
FROM recipe
WHERE JSON_VALUE(ingredient_list, '$.ingredient') = 'banana'
-------------------------------------

DECLARE @jsonInfo NVARCHAR(MAX)

SET @jsonInfo=N'{  
     "info":{    
       "type":1,  
       "address":{    
         "town":"Bristol",  
         "county":"Avon",  
         "country":"England"  
       },  
       "tags":["Sport", "Water polo"]  
    },  
    "type":"Basic"  
 }'  

 SELECT recipe_name,
 JSON_VALUE(@jsonInfo,'$.info.tags[1]') AS tag
FROM recipe
WHERE JSON_VALUE(jsonInfo,'$.info.address[0].state') LIKE 'US%'
ORDER BY JSON_VALUE(jsonInfo,'$.info.address[0].town')