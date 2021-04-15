USE final_capstone
GO

--Insert some ingredients
insert into ingredient (ingredient_name)
values ('banana'), ('flour'), ('zucchini'), ('butter'),
		('eggs'), ('olive oil'), ('chia seeds'), ('maraschino cherries'),
		('sugar'), ('coconut oil'), ('baking soda'), ('baking powder'),
		('mandarin oranges'), ('semi-sweet chocolate chips'), ('canola oil'),
		('brown sugar'), ('cinnamon'), ('nutmeg'), ('salt'), ('chopped pecans'), ('wine vinegar'),
		('unsweetened chocolate'), ('allspice'), ('cloves'), ('ginger'),
		('croissant'), ('apples'), ('peanut butter'), ('romain lettuce head'), ('balsamic vinegar'),
		('chopped walnuts'), ('raisins'), ('sunflower seeds'), ('feta cheese'), ('french onions'),
		('pepitas'), ('tomato'), ('strawberries'), ('blueberries'),('almond milk'), ('protein powder'),
		('red pitaya powder'), ('spinach'), ('raisin bran cereal'), ('pepper'),
		('ground beef'), ('bell pepper'), ('onion'), ('garlic'), ('tomato sauce'), ('tomato paste'),
		('crushed tomato'), ('fresh oregano'), ('fresh parsley'), ('italian seasoning'), ('garlic salt'),
		('lasagna noodles'), ('ricotta cheese'), ('mozzarella cheese'), ('parmesan cheese'),
		('cherry tomatos'), ('couscous'), ('chickpea'), ('lemon juice'), ('fresh herb'), ('cucumber');

--Insert some units
insert into unit (unit_name)
values ('pinch'), ('tsp'), ('tbs'), ('cups'), ('oz'), ('lb'), ('fl oz'), ('pt'), ('qt'), ('gal'), 
('mg'), ('g'), ('ml'), ('l'),
('ea'), ('to taste'), ('cloves'), ('can');

--Insert some recipes
insert into recipe (recipe_name, description, is_public, rating, serves,
	prep_time, cook_time, total_time,
	utensils, instructions, img_url, submitted_by)
values ('banana bread', 'my mother''s recipe, the best!', 1, 5, 8, 30, 45, 75,
	'mixing bowl|mixer|bread pan|oven',
	'thaw bananas|mix all ingredients together|pour in bread pan|bake in oven at 350F|check every half-hour',
	'https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/4/13/0/GC_banana-bread_s4x3.jpg.rend.hgtvcom.826.620.suffix/1371592847747.jpeg', 'zach');

insert into recipe (recipe_name, description, is_public, rating, serves,
	prep_time, cook_time, total_time,
	utensils, instructions, img_url, submitted_by)
values ('chocolate zucchini bread', 'christina''s recipe, the best!', 1, 5, 8, 45, 60, 105,
	'mixing bowl|mixer|2 bread pan|oven',
	'Preheat oven to 350F.,Grease pans.|
	In large bowl, combine flour, baking powder, baking soda, allspice, cinnamon, cloves, and salt. Set aside.|
	In large mixing bowl with mixer at medium speed, beat oil and sugar.|
	Add eggs to oil and sugar mixture, one at a time.|
	Gradually beat in melted chocolate.|
	Add dry ingredients and beat until smooth.|
	Fold in shredded zucchini, chocolate chips, and pecans.|
	Pour into greased and floured pan.|
	Bake for 1 hour and 20 minuted or until toothpick comes out clean.|
	Cool in pan for 20 minutes before removing.',
	'https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimages.media-allrecipes.com%2Fuserphotos%2F1181288.jpg&w=1200&h=678&c=sc&poi=face&q=85', 'zach');

insert into recipe (recipe_name, description, is_public, rating, serves,
	prep_time, cook_time, total_time,
	utensils, instructions, img_url, submitted_by)
values ('egg on a croissant', 'A nice simple meal!', 1, 5, 2, 15, 20, 35,
	'skillet|oven|plates',
	'butter the croissants and put them in the oven to melt the butter|
	fry an egg in the skillet till done the way you like,put the egg on the croissant|
	enjoy',
	'https://www.thehopelesshousewife.com/wp-content/uploads/2012/05/Croissant-Eggs-Benedict2.jpg', 'zach');

insert into recipe (recipe_name, description, is_public, rating, serves,
	prep_time, cook_time, total_time,
	utensils, instructions, img_url, submitted_by)
values ('apples with peanut butter', 'A nice simple meal!', 1, 5, 2, 5, 0, 5,
	'knife|bowl|spoons',
	'cut up the apple into slices|
	slather the peanut butter on each slice with a spoon|
	enjoy',
	'https://stellar.ie/wp-content/uploads/2015/07/Apple-slices-and-peanut-butter.jpg', 'zach');

insert into recipe (recipe_name, description, is_public, rating, serves,
	prep_time, cook_time, total_time,
	utensils, instructions, img_url, submitted_by)
values ('super salad', 'full of green goodness (and protein)!', 1, 5, 2, 30, 0 , 30,
	'knife|salad spinner|2 large bowl|forks',
	'chop the romain into thin strips|wash the lettuce in the salad spinner|
	put chopped lettuce in the bowls|chop the tomato and add to lettuce|add all the toppings|
	enjoy',
	'https://stellar.ie/wp-content/uploads/2015/07/Apple-slices-and-peanut-butter.jpg', 'zach');

insert into recipe (recipe_name, description, is_public, rating, serves,
	prep_time, cook_time, total_time,
	utensils, instructions, img_url, submitted_by)
values ('rockin'' fruit smoothie', 'full of pink goodness (and protein)!', 1, 5, 2, 20, 0, 20,
	'blender|2 large cups|spoons',
	'blend it all|pour into cups,
	enjoy',
	'https://i.pinimg.com/originals/c7/53/8f/c7538fb4223d92523f190220bfe5513b.jpg', 'zach');

insert into recipe (recipe_name, description, is_public, rating, serves,
	prep_time, cook_time, total_time,
	utensils, instructions, img_url, submitted_by)
values ('bananas in cereal', 'a way to add bananas to breakfast!', 1, 5, 2, 10, 0, 10,
	'knife|bowl|spoons',
	'cut up the bananas into slices|
	put banana slices along with cereal and milk into a bowl|
	enjoy',
	'https://i0.wp.com/www.theimpulsivebuy.com/wordpress/wp-content/uploads/2018/06/Kelloggs-Raisin-Bran-with-Bananas-2.jpg?resize=550%2C550&ssl=1', 'zach');

insert into recipe (recipe_name, description, is_public, rating, serves,
	prep_time, cook_time, total_time,
	utensils, instructions, img_url, submitted_by)
values ('bananas with peanut butter', 'A nice simple meal!', 1, 5, 2, 5, 0, 5,
	'knife|bowl|spoons',
	'cut up the banana into slices|
	slather the peanut butter on each slice with a spoon|
	enjoy',
	'https://www.parentaljourney.com/wp-content/uploads/2016/02/2-bananas-with-peanut-butter.jpg', 'zach');

insert into recipe (recipe_name, description, is_public, rating, serves,
	prep_time, cook_time, total_time,
	utensils, instructions, img_url, submitted_by)
values ('lasagna', 'best lasagna in the world', 1, 5, 8, 15, 90, 105,
	'skillet|midium sized pot|9 x 13-inch casserole dish',
	'brown the ground beef, set aside|cook bell pepper, onoions, garlic, add back the beef|
	transfer to medium sized pot|add tomatos, tomato sauce, tomato paste, parsrly, oregano, italian seasoning|sprinkle with garlic salt|sprinkle with red or white wine vinegar|bring to simmer and lower the heat|cook for 15 to 45 mins|
	boil and drain the lasagna noodles|assemble the lasagna with sauce, cheese, pasta in a casserole dish|bake at 375F for 45 mins',
	'https://www.simplyrecipes.com/thmb/dWEVorTSuZUmOYPr6pxk4SnK_F8=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2004__12__lasagna-horiz-a-2000-a4631232672d4609b12b94da7a20ef90.jpg', 'Michiyo');

insert into recipe (recipe_name, description, is_public, rating, serves,
	prep_time, cook_time, total_time,
	utensils, instructions, img_url, submitted_by)
values ('Couscous Salad', 'perfect for lunch', 1, 5, 8, 20, 20, 40,
	'mixing bowl',
	'roast half of tomatos|cook pearl couscous|make roasted chickpeas|
	mix fresh tomato, roasted tomato, couscous, chickpeas, olive oil, lemon juice, garlic, fresh hearbs, cucumbers, feta cheese',
	'https://www.wellplated.com/wp-content/uploads/2016/07/Israeli-Couscous-Salad-Feta.jpg', 'Michiyo');

--Add the recipes to user
insert into recipe_users (recipe_id, user_id)
values ((select recipe_id from recipe where recipe_name = 'banana bread'),
		(select user_id from users where username = 'user'));

insert into recipe_users (recipe_id, user_id)
values ((select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select user_id from users where username = 'user'));

insert into recipe_users (recipe_id, user_id)
values ((select recipe_id from recipe where recipe_name = 'lasagna'),
		(select user_id from users where username = 'user'));

insert into recipe_users (recipe_id, user_id)
values ((select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select user_id from users where username = 'user'));

--Add ingredients to recipe
insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'banana'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'ea'), 4),
		((select ingredient_id from ingredient where ingredient_name = 'sugar'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 0.75),
		((select ingredient_id from ingredient where ingredient_name = 'chia seeds'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'tbs'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'flour'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'coconut oil'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'tbs'), 3),
		((select ingredient_id from ingredient where ingredient_name = 'baking soda'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'tsp'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'salt'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'tsp'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'mandarin oranges'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'maraschino cherries'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'semi-sweet chocolate chips'),
		(select recipe_id from recipe where recipe_name = 'banana bread'),
		(select unit_id from unit where unit_name = 'cups'), 1);

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'zucchini'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'cups'), 3),
		((select ingredient_id from ingredient where ingredient_name = 'brown sugar'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'cups'), 2.33),
		((select ingredient_id from ingredient where ingredient_name = 'eggs'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'ea'), 4),
		((select ingredient_id from ingredient where ingredient_name = 'flour'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'cups'), 3),
		((select ingredient_id from ingredient where ingredient_name = 'canola oil'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'cups'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'baking soda'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'tsp'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'baking powder'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'tsp'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'salt'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'tsp'), 1.25),
		((select ingredient_id from ingredient where ingredient_name = 'unsweetened chocolate'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'oz'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'semi-sweet chocolate chips'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'cups'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'allspice'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'tsp'), 0.25),
		((select ingredient_id from ingredient where ingredient_name = 'cinnamon'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'tsp'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'chopped pecans'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'),
		(select unit_id from unit where unit_name = 'cups'), 1);

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'eggs'),
		(select recipe_id from recipe where recipe_name = 'egg on a croissant'),
		(select unit_id from unit where unit_name = 'ea'), 6),
		((select ingredient_id from ingredient where ingredient_name = 'croissant'),
		(select recipe_id from recipe where recipe_name = 'egg on a croissant'),
		(select unit_id from unit where unit_name = 'ea'), 3);

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'apples'),
		(select recipe_id from recipe where recipe_name = 'apples with peanut butter'),
		(select unit_id from unit where unit_name = 'ea'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'peanut butter'),
		(select recipe_id from recipe where recipe_name = 'apples with peanut butter'),
		(select unit_id from unit where unit_name = 'cups'), 4);

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'romain lettuce head'),
		(select recipe_id from recipe where recipe_name = 'super salad'),
		(select unit_id from unit where unit_name = 'ea'), 3),
		((select ingredient_id from ingredient where ingredient_name = 'tomato'),
		(select recipe_id from recipe where recipe_name = 'super salad'),
		(select unit_id from unit where unit_name = 'ea'), 4),
		((select ingredient_id from ingredient where ingredient_name = 'balsamic vinegar'),
		(select recipe_id from recipe where recipe_name = 'super salad'),
		(select unit_id from unit where unit_name = 'cups'), (2.0/3.0)),
		((select ingredient_id from ingredient where ingredient_name = 'olive oil'),
		(select recipe_id from recipe where recipe_name = 'super salad'),
		(select unit_id from unit where unit_name = 'cups'), (2.0/3.0)),
		((select ingredient_id from ingredient where ingredient_name = 'raisins'),
		(select recipe_id from recipe where recipe_name = 'super salad'),
		(select unit_id from unit where unit_name = 'cups'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'chopped walnuts'),
		(select recipe_id from recipe where recipe_name = 'super salad'),
		(select unit_id from unit where unit_name = 'cups'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'sunflower seeds'),
		(select recipe_id from recipe where recipe_name = 'super salad'),
		(select unit_id from unit where unit_name = 'cups'), (2.0/3.0)),
		((select ingredient_id from ingredient where ingredient_name = 'pepitas'),
		(select recipe_id from recipe where recipe_name = 'super salad'),
		(select unit_id from unit where unit_name = 'cups'), (2.0/3.0)),
		((select ingredient_id from ingredient where ingredient_name = 'feta cheese'),
		(select recipe_id from recipe where recipe_name = 'super salad'),
		(select unit_id from unit where unit_name = 'cups'), (2.0/3.0)),
		((select ingredient_id from ingredient where ingredient_name = 'french onions'),
		(select recipe_id from recipe where recipe_name = 'super salad'),
		(select unit_id from unit where unit_name = 'cups'), (2.0/3.0));

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'banana'),
		(select recipe_id from recipe where recipe_name = 'rockin'' fruit smoothie'),
		(select unit_id from unit where unit_name = 'ea'), 4),
		((select ingredient_id from ingredient where ingredient_name = 'peanut butter'),
		(select recipe_id from recipe where recipe_name = 'rockin'' fruit smoothie'),
		(select unit_id from unit where unit_name = 'cups'), 4),
		((select ingredient_id from ingredient where ingredient_name = 'strawberries'),
		(select recipe_id from recipe where recipe_name = 'rockin'' fruit smoothie'),
		(select unit_id from unit where unit_name = 'cups'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'red pitaya powder'),
		(select recipe_id from recipe where recipe_name = 'rockin'' fruit smoothie'),
		(select unit_id from unit where unit_name = 'tbs'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'protein powder'),
		(select recipe_id from recipe where recipe_name = 'rockin'' fruit smoothie'),
		(select unit_id from unit where unit_name = 'cups'), (1.0/2.0)),
		((select ingredient_id from ingredient where ingredient_name = 'almond milk'),
		(select recipe_id from recipe where recipe_name = 'rockin'' fruit smoothie'),
		(select unit_id from unit where unit_name = 'cups'), 1);

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'banana'),
		(select recipe_id from recipe where recipe_name = 'bananas in cereal'),
		(select unit_id from unit where unit_name = 'ea'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'raisin bran cereal'),
		(select recipe_id from recipe where recipe_name = 'bananas in cereal'),
		(select unit_id from unit where unit_name = 'cups'), 4),
		((select ingredient_id from ingredient where ingredient_name = 'almond milk'),
		(select recipe_id from recipe where recipe_name = 'bananas in cereal'),
		(select unit_id from unit where unit_name = 'cups'), 3);

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'banana'),
		(select recipe_id from recipe where recipe_name = 'bananas with peanut butter'),
		(select unit_id from unit where unit_name = 'ea'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'peanut butter'),
		(select recipe_id from recipe where recipe_name = 'bananas with peanut butter'),
		(select unit_id from unit where unit_name = 'cups'), 4);

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'ground beef'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'lb'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'onion'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'cups'), 0.5),
		((select ingredient_id from ingredient where ingredient_name = 'olive oil'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'tbs'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'bell pepper'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'cups'), 0.75),
		((select ingredient_id from ingredient where ingredient_name = 'garlic'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'cloves'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'tomato sauce'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'can'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'tomato paste'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'can'), 0.5),
		((select ingredient_id from ingredient where ingredient_name = 'crushed tomato'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'can'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'fresh oregano'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'tbs'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'fresh parsley'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'cups'), 0.75),
		((select ingredient_id from ingredient where ingredient_name = 'italian seasoning'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'tbs'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'garlic salt'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'pinch'), 1),
		((select ingredient_id from ingredient where ingredient_name = 'wine vinegar'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'tbs'), 1),
        ((select ingredient_id from ingredient where ingredient_name = 'lasagna noodles'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'lb'), 0.5),
        ((select ingredient_id from ingredient where ingredient_name = 'ricotta cheese'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'oz'), 15),
		((select ingredient_id from ingredient where ingredient_name = 'mozzarella cheese'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'oz'), 24),
		((select ingredient_id from ingredient where ingredient_name = 'parmesan cheese'),
		(select recipe_id from recipe where recipe_name = 'lasagna'),
		(select unit_id from unit where unit_name = 'oz'), 4);

insert into ingredient_recipe_unit (ingredient_id, recipe_id, unit_id, qty)
values ((select ingredient_id from ingredient where ingredient_name = 'cherry tomatos'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'ea'), 8),
		((select ingredient_id from ingredient where ingredient_name = 'couscous'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'cups'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'chickpea'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'cups'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'cucumber'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'ea'), 2),
		((select ingredient_id from ingredient where ingredient_name = 'olive oil'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'tbs'), 1.5),
		((select ingredient_id from ingredient where ingredient_name = 'lemon juice'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'tbs'), 3),
		((select ingredient_id from ingredient where ingredient_name = 'feta cheese'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'oz'), 4),
		((select ingredient_id from ingredient where ingredient_name = 'fresh herb'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'cups'), 0.5),
        ((select ingredient_id from ingredient where ingredient_name = 'garlic'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'),
		(select unit_id from unit where unit_name = 'tbs'), 1.5);


--Insert some categories
insert into category (category_name)
values ('quick bread');

insert into category (category_name)
values ('breakfast');

insert into category (category_name)
values ('lunch');

insert into category (category_name)
values ('dinner');

insert into category (category_name)
values ('snack');

--Add the categories to the recipes
insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='quick bread'),
		(select recipe_id from recipe where recipe_name = 'banana bread'));

insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='quick bread'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'));

insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='dinner'),
		(select recipe_id from recipe where recipe_name = 'super salad'));

insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='dinner'),
		(select recipe_id from recipe where recipe_name = 'rockin'' fruit smoothie'));

insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='breakfast'),
		(select recipe_id from recipe where recipe_name = 'egg on a croissant'));

insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='breakfast'),
		(select recipe_id from recipe where recipe_name = 'bananas in cereal'));

insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='dinner'),
		(select recipe_id from recipe where recipe_name = 'lasagna'));

insert into category_recipe (category_id, recipe_id)
values ((select category_id from category where category_name='lunch'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'));

--Add some meals
insert into meal (meal_name, user_id)
values ('Monday Breakfast',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Monday Lunch',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Monday Dinner',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Tuesday Breakfast',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Tuesday Lunch',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Tuesday Dinner',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Wednesday Breakfast',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Wednesday Lunch',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Wednesday Dinner',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Thursday Breakfast',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Thursday Lunch',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Thursday Dinner',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Friday Breakfast',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Friday Lunch',
		(select user_id from users where username = 'user'));

insert into meal (meal_name, user_id)
values ('Friday Dinner',
		(select user_id from users where username = 'user'));

--Add meal and recipe to meal
insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Monday Breakfast'),
		(select recipe_id from recipe where recipe_name = 'egg on a croissant'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Monday Lunch'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Monday Dinner'),
		(select recipe_id from recipe where recipe_name = 'lasagna'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Tuesday Breakfast'),
		(select recipe_id from recipe where recipe_name = 'bananas in cereal'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Tuesday Lunch'),
		(select recipe_id from recipe where recipe_name = 'apples with peanut butter'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Tuesday Dinner'),
		(select recipe_id from recipe where recipe_name = 'super salad'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Wednesday Breakfast'),
		(select recipe_id from recipe where recipe_name = 'egg on a croissant'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Wednesday Lunch'),
		(select recipe_id from recipe where recipe_name = 'bananas with peanut butter'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Wednesday Dinner'),
		(select recipe_id from recipe where recipe_name = 'rockin'' fruit smoothie'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Thursday Breakfast'),
		(select recipe_id from recipe where recipe_name = 'egg on a croissant'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Thursday Lunch'),
		(select recipe_id from recipe where recipe_name = 'banana bread'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Thursday Dinner'),
		(select recipe_id from recipe where recipe_name = 'super salad'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Friday Breakfast'),
		(select recipe_id from recipe where recipe_name = 'chocolate zucchini bread'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Friday Lunch'),
		(select recipe_id from recipe where recipe_name = 'couscous salad'));

insert into meal_recipe (meal_id, recipe_id)
values ((select meal_id from meal where meal_name = 'Friday Dinner'),
		(select recipe_id from recipe where recipe_name = 'lasagna'));

--Add a new plan
insert into mplan (mplan_name, user_id)
values ('the average week',
		(select user_id from users where username = 'user'));

insert into meal_mplan (meal_id, mplan_id, meal_day, meal_time)
values ((select meal_id from meal where meal_name = 'Monday Breakfast'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'monday', 'breakfast'),
		((select meal_id from meal where meal_name = 'Monday Lunch'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'monday', 'lunch'),
		((select meal_id from meal where meal_name = 'Monday Dinner'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'monday', 'dinner'),
		((select meal_id from meal where meal_name = 'Tuesday Breakfast'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'tuesday', 'breakfast'),
		((select meal_id from meal where meal_name = 'Tuesday Lunch'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'tuesday', 'lunch'),
		((select meal_id from meal where meal_name = 'Tuesday Dinner'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'tuesday', 'dinner'),
		((select meal_id from meal where meal_name = 'Wednesday Breakfast'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'wednesday', 'breakfast'),
		((select meal_id from meal where meal_name = 'Wednesday Lunch'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'wednesday', 'lunch'),
		((select meal_id from meal where meal_name = 'Wednesday Dinner'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'wednesday', 'dinner'),
		((select meal_id from meal where meal_name = 'Thursday Breakfast'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'thursday', 'breakfast'),
		((select meal_id from meal where meal_name = 'Thursday Lunch'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'thrusday', 'lunch'),
		((select meal_id from meal where meal_name = 'Thursday Dinner'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'thursday', 'dinner'),
		((select meal_id from meal where meal_name = 'Friday Breakfast'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'friday', 'breakfast'),
		((select meal_id from meal where meal_name = 'Friday Lunch'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'friday', 'lunch'),
		((select meal_id from meal where meal_name = 'Friday Dinner'),
		(select mplan_id from mplan where mplan_name = 'the average week'), 'friday', 'dinner');