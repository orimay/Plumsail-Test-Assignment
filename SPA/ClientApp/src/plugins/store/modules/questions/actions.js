import axios from "axios"; 
import QuestionPresets from "@/constants/question-presets";

export default {

  async mock({ dispatch, commit }) {
    const questionSets = [];
    for (const questionSet of QuestionPresets) {
      questionSets.push(dispatch('save', { questionSet }));
    }
    await axios.all(questionSets);
  },

  async save({ dispatch, commit }, { questionSet }) {
    await axios.post("questionset", questionSet);
  },

  async load({ dispatch, commit }, { questionSetId } = { questionSetId: undefined }) {
    if (questionSetId) {
      return await axios.get(`questionset/${questionSetId}`);
    }

    const result = await axios.get("questionset/list");
    if (result.isSuccess) {
      commit("questionSetsLoaded", result.data);
    }
  }

};
