/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ingredient_id]
      ,[recipe_id]
      ,[unit_id]
      ,[qty]
  FROM [final_capstone].[dbo].[ingredient_recipe_unit]

select recipe_name, ingredient_name, sum(qty) as total, unit_name
from ingredient_recipe_unit
join recipe on recipe.recipe_id = ingredient_recipe_unit.recipe_id
join ingredient on ingredient.ingredient_id = ingredient_recipe_unit.ingredient_id
join unit on unit.unit_id = ingredient_recipe_unit.unit_id
group by recipe_name, ingredient_name, unit_name