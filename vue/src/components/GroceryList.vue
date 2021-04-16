<template>
<div class="grocery-list">

<h1>{{this.$store.state.userPlanList[this.$store.state.currentPlanId - 1].name}}</h1>
<table id='table-list'>
   <tr id='first-row'>
    <th class='column-1'>Ingredient</th>
    <th class='table-heading'>Qty</th>
    <th class='table-heading'>Unit</th>
  </tr> 
  <tr v-for='item in Groceries' 
v-bind:key='item.name'>
    <td class='column-1'>{{item.name}}</td>
    <td>{{item.qty}}</td>
    <td class='column-3'>{{item.unit}}</td>
  </tr>
</table>



<!--
 <h1>Groceries: {{Groceries}}</h1> -->




</div>

</template>

<script>
import PlanService from "../services/PlanService";

export default {
  name: "grocery-list",
  data() {
    return {
      Groceries: []
    };
  },
  created() {
    PlanService.getGroceries(this.$store.state.currentPlanId).then((response) => {
      this.Groceries = response.data;


    });
  }
};
</script>

<style>


.table-heading{
  text-decoration: underline;
  
}
#table-list {
  padding: 20px 20px;
  margin: 20 auto;
  max-width: 600px;

} 
.grocery-list {
 
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center flex-start;
  box-shadow:0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  border-radius: 5px;
  width: .5fr;
  margin: 5px 10px 5px 10px;
  padding: 0px 0px 0px 0px;

}
.column-1{
  width: 80%;
}

.colum-3{
width: 20%;

}


table{
  width: 60%;
  table-layout: auto;
}
th{
  width: 100%;
  text-align: left;
  margin-bottom: 10px;
}

#first-row{
  margin-bottom: 10px;
  height: 90px;

}

h1{
  margin-top: 20px;
      text-transform: capitalize;
}


</style>