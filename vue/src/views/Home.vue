<template>
  <div class="home">

    <h1>Your Meal Plans</h1>

<plan-list></plan-list>




  </div>
</template>

<script>
import PlanList from "@/components/PlanList";
export default {
    components: {
    PlanList
  },
  name: "home"
};
</script>
<style scoped>
.home{
/* border: 1px black solid;
width: 1000px;
margin: 0px auto 0px;
padding: 20px; */

}


</style>

