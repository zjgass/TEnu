<template>
<div>


<form action="" method="">
<p> Add a meal to which day: </p>
<select name="day">
<option value="parrot"> Monday </option>
<option value="skyline"> Tuesday </option>
<option value="alumina"> Wednesday </option>
<option value="alumina"> Thursday </option>
<option value="alumina"> Friday </option>
</select>

<p> Choose a meal to add to this plan: </p>
<select name="recipe" size='5' multiple='multiple'>
<option value="parrot"> list all meals here </option>

</select>
<p id='ctrl'> use ctrl + click to add multiple recipes </p>

      <button >Add Meals</button>
</form>


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