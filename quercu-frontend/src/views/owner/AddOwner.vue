<template>
<div class="mt-3 mx-5">
    <div class="shadow-lg p-3 mb-5 bg-white rounded">
      <div class="card-header py-3 d-flex bd-highlight mb-3">
        <h5 class="m-0 font-weight-bold mr-auto p-2 bd-highlight">
          Properties
        </h5>
      </div>
      <form @submit.prevent="addOwner">
          <p v-if="errors.length">
                <b>Please, check the errors</b>
                <ul>
                    <li v-for="error in errors">{{ error }}</li>
                </ul>
            </p>
        <div class="form-row">
          <div class="form-group col-md-6">
            <span>
              <label>Name</label>
              <input
                type="text"
                class="form-control"
                placeholder="Name"
                v-model="owner.name"
              />
            </span>
          </div>
          <div class="form-group col-md-6">
            <label>Phone</label>
            <input
              type="text"
              class="form-control"
              placeholder="Phone"
              v-model="owner.telephone"
            />
          </div>
          <div class="form-group col-md-6">
            <label>Email</label>
            <input
              type="email"
              class="form-control"
              placeholder="Email"
              v-model="owner.email"
            />
          </div>
          <div class="form-group col-md-6">
            <label>Identification Number</label>
            <input
              type="string"
              class="form-control"
              placeholder="Identification Number"
              v-model.number="owner.identificationNumber"
            />
          </div>

          <div class="form-group col-md-6">
            <label>Address</label>
            <input
              type="string"
              class="form-control"
              placeholder="Address"
              v-model.number="owner.address"
            />
          </div>
          
        </div>
        <input type="submit" class="btn btn-primary" />
      </form>
    </div>
  </div>
</template>

<script>
export default {
  data: () => ({
    owner: {
      name: "",
      telephone: "",
      email: "",
      identificationNumber: "",
      address: "",
    },
    errors: [],
  }),
  methods: {
    async addOwner() {
      if (
        this.owner.name != "" &&
        this.owner.telephone != "" &&
        this.owner.email != "" &&
        this.owner.identificationNumber != "" &&
        this.owner.address != ""
      ) {
        this.axios.post(
          "https://localhost:44384/Owner" + "/",
          this.owner
        );
        window.history.back();
      }

      this.errors = [];

      if (this.owner.name == "") {
        this.errors.push("The name  is required");
      }

      if (this.owner.telephone == "") {
        this.errors.push("The telephone is required");
      }

      if (this.owner.identificationNumber == "") {
        this.errors.push("The identity number is required");
      }

    },
  },
};
</script>