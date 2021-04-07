<template>
<div>
<div id='new-recipe-page'>

<form id='recipe-input' action="" method="">

<p> Add a meal to which day: </p>
<select name="">
<option value=""> Monday </option>
<option value=""> Tuesday </option>
<option value=""> Wednesday </option>
<option value=""> Thursday </option>
<option value=""> Friday </option>
</select>

<p> Choose a meal to add to this day: </p>
<select name="recipe" size='5' multiple='multiple'>
<option value="meal-name"> list all meals here </option>

</select>
<p id='ctrl'> use ctrl + click to add multiple recipes </p>

      <button >Add Meals</button>

<div class='input-line'>
    <p class='input-label'>name of new meal plan: </p>
    <input type='text' name = 'recipe-name'  />

</div>



        <button  id='submit-button'>Submit Plan</button>
</form>

<div id='current-recipe'>
<h2>Meal Plan Name: </h2>
<p> bind plan name </p>


<h2>Meals Included: </h2>
<ul>


<li>list item in meal list</li>

</ul>

    </div>


</div>
    </div>
</template>

<script>
export default {

}
</script>

<style>


#form{

}

</style>