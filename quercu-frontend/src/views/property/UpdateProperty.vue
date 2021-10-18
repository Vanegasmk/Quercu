<template>
<div class="mt-3 mx-5">
    <div class="shadow-lg p-3 mb-5 bg-white rounded">
      <div class="card-header py-3 d-flex bd-highlight mb-3">
        <h5 class="m-0 font-weight-bold mr-auto p-2 bd-highlight">
          Properties
        </h5>
      </div>
      <form @submit.prevent="updateProperty">
          <p v-if="errors.length">
                <b>Please, check the errors</b>
                <ul>
                    <li v-for="error in errors">{{ error }}</li>
                </ul>
            </p>
        <div class="form-row">
          <div class="form-group col-md-6">
            <span>
              <label>Number</label>
              <input
                type="text"
                class="form-control"
                placeholder="Number"
                v-model="property.number"
              />
            </span>
          </div>
          <div class="form-group col-md-6">
            <label>Address</label>
            <input
              type="text"
              class="form-control"
              placeholder="Address"
              v-model="property.address"
            />
          </div>
          <div class="form-group col-md-6">
            <label>Area</label>
            <input
              type="number"
              class="form-control"
              placeholder="Area"
              step="any"
              v-model.number="property.area"
            />
          </div>
          <div class="form-group col-md-6">
            <label>Construction Area</label>
            <input
              type="number"
              class="form-control"
              placeholder="Construction Area"
              step="any"
              v-model.number="property.constructionArea"
            />
          </div>
          <div class="form-group col-md-6">
            <label>Owner</label>
            <select v-model.number="property.ownerId" class="form-control">
              <option v-for="owner in owners" v-bind:value="owner.id">
                {{owner.name}}
              </option>
            </select>
          </div>
          <div class="form-group col-md-6">
            <label>Property Type</label>
            <select v-model.number="property.propertyTypeId" class="form-control">
              <option v-for="propertyType in propertyTypes" v-bind:value="propertyType.id">
                {{propertyType.description}}
              </option>
            </select>
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
    property: {
      id: 0,
      propertyTypeId: 0,
      ownerId: 0,
      number: "",
      address: "",
      area: 0,
      constructionArea: 0,
    },
    errors: [],
    owners: null,
    propertyTypes: null,
  }),
  mounted() {
      this.getProperty();
      this.getOwners();
      this.getPropertyTypes();
  },
  methods: {
    async getProperty() {
      this.axios
        .get(
          "https://localhost:44384/Property/Property?id=" +
            this.$route.params.id
        )
        .then(
          (response) => (
              this.property.id = response.data.id,
              this.property.propertyTypeId = response.data.propertyTypeId,
              this.property.ownerId = response.data.ownerId,
              this.property.number = response.data.number,
              this.property.address = response.data.address,
              this.property.area = response.data.area,
              this.property.constructionArea = response.data.constructionArea
          ));
    },
    async getOwners() {
      const data = await this.axios
        .get("https://localhost:44384/Owner")
        .then((response) => (this.owners = response.data));
    },
    async getPropertyTypes() {
      const data = await this.axios
        .get("https://localhost:44384/PropertyType")
        .then((response) => (this.propertyTypes = response.data));
    },
    async updateProperty() {
      if (
        this.property.propertyTypeId > 0 &&
        this.property.ownerId > 0 &&
        this.property.number != "" &&
        this.property.address != "" &&
        this.property.area != ""
      ) {
        this.axios.post(
          "https://localhost:44384/Property" + "/",
          this.property
        );
        window.history.back();
      }

      this.errors = [];

      if (this.property.propertyTypeId == 0) {
        this.errors.push("The Property Type is required");
      }

      if (this.property.ownerId == 0) {
        this.errors.push("The Owner is required");
      }

      if (this.property.number == 0) {
        this.errors.push("The Number is required");
      }

      if (this.property.address == "") {
        this.errors.push("The Address is required");
      }

      if (this.property.area == "") {
        this.errors.push("The Area is required");
      }
    },
  },
};
</script>