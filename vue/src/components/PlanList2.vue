
<template>
<div>
<form id='choose-plan' action="" method="">

<p> Choose a plan to display: </p>
<select name="">
<option value=""> list of plans here </option>
<option value=""> Tuesday </option>
<option value=""> Wednesday </option>
<option value=""> Thursday </option>
<option value=""> Friday </option>
</select>
</form>


<h1>*plan name from box</h1>

<div id='meal-plan'>
<div class='plan-column' id='monday'>
    <h1>Monday</h1>
    <h2>Breakfast:</h2>
    <li>name of meal</li>
</div>

<div class='plan-column' id='tuesday'>
        <h1>Monday</h1>
</div>

<div class='plan-column' id='wednesday'>
        <h1>Monday</h1>
</div>

<div class='plan-column' id='thursday'>
        <h1>Monday</h1>
</div>

<div class='plan-column' id='friday'>
        <h1>Monday</h1>
</div>

</div>


</div>
</template>

<script>
// import docsService from "../services/DocsService";

// export default {
//   name: "meal-plan-list",
//   data() {
//     return {
//       allPlans: []
//     };
//   },
//   methods: {
//     viewDocument(id) {
//       this.$router.push(`/plans/${planId}`);
//     }
//   },
//   created() {
//     docsService.list().then((response) => {
//       this.allPlans = response.data;
//     });
//   }
// };
</script>

<style>

.plan-item{
color: white;

list-style-type: none;
margin: 0px auto 10px;
padding: 10px;
width: 900px;
background-color: #1789fc;
height: 30px;
border-radius: 5px;
border: 1px solid black;

}

#meal-plan{
    border: 1px solid black;
    border-radius: 5px;
    min-height: 400px;
    background-color:#296eb4;
    display:flex;
    flex-direction: row;
    justify-content: space-around;

}
.plan-column{
    color: white;
    width: 18%;
    min-height: 50px;
    background-color:#1789fc;
    border: 1px solid black;
    margin: 10px;
    padding: 10px;
    border-radius: 5px;
}

.plan-column h1{
    margin-top: 0px;
    text-decoration: underline;
}
#choose-plan{
    /* border: 1px solid black; */
}

</style>