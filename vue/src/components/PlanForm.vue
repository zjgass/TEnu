<template>
<div>
<div id='form-page'>

<form id='plan-input' action="" method="">

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

<div id='current-plan'>
<h2>Meal Plan Name: </h2>
<p> bind plan name </p>


<h2>Meals Included: </h2>
<ul>


<li></li>

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



#plan-input, #current-plan{

width: 45%;
min-height: 600px;
  box-shadow:0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  border-radius: 5px;
  padding: 20px;

}

@media(max-width: 1400px) {

#plan-input, #current-plan{

width: 95%;
width: 95%;

}
#form-page{
    display:flex;
    flex-direction: column;
}

}


</style>