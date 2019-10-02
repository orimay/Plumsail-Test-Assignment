import axios from "axios";

export default {

  async save({ dispatch, commit }, { answerSet }) {
    await axios.post("answerset", answerSet);
  },

  async load({ dispatch, commit }, { searchValue }) {
    const result = await axios.get("answerset/list", { params: { searchValue } });
    if (result.isSuccess) {
      commit("answerSetsLoaded", result.data);
    }
  }

};
