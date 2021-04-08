
<template>
<div>


<div id='top-of-component'>

<div id='current-plan'>
    <h1>Your Meal Plan</h1>
    <h2>*name of current selected plan</h2>

    </div>


<form id='choose-plan' action="" method="">
<p> View A Different Meal Plan: </p>
<select name="select-plan">
<option value=""> select plan </option>
<option value=""> plan name </option>
<option value=""> plan name </option>
<option value=""> plan name </option>
<option value=""> plan name </option>
</select>
</form>





</div>


<div id='meal-plan'>
<div class='plan-column' id='monday'>
    <h1 class='day'>Monday</h1>
    <p>meal card</p>
</div>

<div class='plan-column' id='tuesday'>
        <h1 class='day'>Tuesday</h1>
</div>

<div class='plan-column' id='wednesday'>
        <h1 class='day'>Wednesday</h1>
</div>

<div class='plan-column' id='thursday'>
        <h1 class='day'>Thursday</h1>
</div>

<div class='plan-column' id='friday'>
        <h1 class='day'>Friday</h1>
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

border: 1px solid black;

}

#meal-plan{
    /* border: 1px solid black; */

    min-height: 400px;

    display:flex;
    flex-direction: row;
    justify-content: space-around;

}
.plan-column{
/* background-color: silver; */
width: 100%;
text-align: center;

padding: 20px;
    /* background-color: limegreen; */
}

.plan-column:not(:first-of-type){

    border-left: 1px solid black;
}

#current-plan, h1{
    margin-top: 0px;
}

.plan-column h1{
    margin-top: 0px;
    text-decoration: underline;
        background-color: darkcyan;
    height: 45px;
    color: white;

    
}
#top-of-component{
    /* border: 1px solid black; */
    display: flex;
    flex-direction: row;
    justify-content: space-between;
}

#current-plan{

    width: 50%;
    height: 100px;
}


#choose-plan, #current-plan{
    margin: 10px;
}

#select-plan{
font-size: 36pt;
background-color:
}


</style>