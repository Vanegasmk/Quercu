<template>
<div class="mt-3 mx-5">
      <div class="shadow-lg p-3 mb-5 bg-white rounded">
      <div class="card-header py-3 d-flex bd-highlight mb-3">
        <h5 class="m-0 font-weight-bold mr-auto p-2 bd-highlight">
          Property Type
        </h5>
      </div>
      <form @submit.prevent="updatePropertyType">
          <p v-if="errors.length">
                <b>Please, check the errors</b>
                <ul>
                    <li v-for="error in errors">{{ error }}</li>
                </ul>
            </p>
        <div class="form-row">
          <div class="form-group col-md-6">
            <span>
              <label>Description</label>
              <input
                type="text"
                class="form-control"
                placeholder="Description"
                v-model="propertyType.description"
              />
            </span>
          </div>
        </div>
        <input type="submit" class="btn btn-primary" value="Send" />
      </form>
    </div>
  </div>
</template>
<script>
export default {
  data: () => ({
    propertyType: {
      id: 0,
      description: "",
    },
    errors: [],
  }),
  mounted() {
    this.getPropertyType();
  },
  methods: {
    async getPropertyType() {
      this.axios
        .get(
          "https://localhost:44384/PropertyType/PropertyType?id=" +
            this.$route.params.id
        )
        .then(
          (response) => (
            this.propertyType.id = response.data.id,
            this.propertyType.description = response.data.description
          )
        );
    },
    async updatePropertyType() {
      if (this.propertyType.description != "") {
        this.axios.post(
          "https://localhost:44384/PropertyType" + "/",
          this.propertyType
        );
        window.history.back();
      }

      this.errors = [];

      if (this.propertyType.description == "") {
        this.errors.push("The description is required");
      }
    },
  },
};
</script>