import Answers from "./answers/";
import Questions from "./questions/";

export default {
  answers: { ...Answers, namespaced: true },
  questions: { ...Questions, namespaced: true }
};
