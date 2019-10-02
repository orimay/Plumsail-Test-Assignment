import Vue from "vue";
import Router from "vue-router";

import ListQuestionSets from "@/views/ListQuestionSets.vue";
import QuestionSet from "@/views/QuestionSet.vue";
import ListAnswerSets from "@/views/ListAnswerSets.vue";

Vue.use(Router);

export default new Router({
  mode: "history",
  scrollBehavior(to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition;
    } else {
      return { x: 0, y: 0 };
    }
  },
  routes: [
    {
      path: "/",
      name: "home",
      redirect: "/list-question-sets"
    },
    {
      name: "list-question-sets",
      path: "/list-question-sets",
      component: ListQuestionSets
    },
    {
      path: "/question-set/:questionSetId",
      name: "question-set",
      component: QuestionSet,
      props: true
    },
    {
      path: "/list-answer-sets",
      name: "list-answer-sets",
      component: ListAnswerSets
    }
  ]
});
