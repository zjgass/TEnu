<template>
<div>

<form action="" method="">
<p>name of new meal: </p>
<input type='text' name = 'meal-name'  />

<p>choose recipes to add: </p>
<select name="recipe" size='5' multiple='multiple'>
<option value="parrot"> list recipes here </option>
<option value="skyline"> asdf </option>
<option value="alumina"> asdf </option>
</select>
<p id='ctrl'> use ctrl + click to add multiple recipes </p>
<button >Add Recipes</button>
</form>

    </div>
</template>

<script>
export default {

}
</script>

<style>


option{
width: 200px;
}

select{
    width: 200px;
}
#ctrl{
    margin-top: 0px;
    font-size: 8pt;
}

</style>