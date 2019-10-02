<template>
  <v-app class="ma-4">
    <v-container>
      <v-app-bar color="pink" dark>
        <v-toolbar-title>{{ title }}</v-toolbar-title>
        <div class="flex-grow-1"></div>
        <v-toolbar-items>
          <v-btn text :to="{ name: 'list-question-sets' }">Question Sets</v-btn>
          <v-btn text :to="{ name: 'list-answer-sets' }">Answer Sets</v-btn>
        </v-toolbar-items>
      </v-app-bar>
      <v-card class="pa-4">
        <router-view @title-update="updateTitle" />
      </v-card>
    </v-container>
  </v-app>
</template>

<style scoped>
.container {
  max-width: 1024px;
}
</style>

<script>
export default {
  data() {
    return {
      title: null
    }
  },
  methods: {
    updateTitle(title) {
      this.title = title;
    }
  }
};
</script>
