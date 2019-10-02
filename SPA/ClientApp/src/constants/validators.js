import * as moment from 'moment';
import ValidatorTypes from './validator-types';

export default {
  [ValidatorTypes.REQUIRED]: message => v => !!(Array.isArray(v) ? v.length : v) || message,
  [ValidatorTypes.MIN_LENGTH]: (length, message) => v => !!v && v.length >= length || message,
  [ValidatorTypes.MAX_LENGTH]: (length, message) => v => !!v && v.length <= length || message,
  [ValidatorTypes.MIN_YEARS_AGO]: (yearsCount, message) => v => moment().subtract(yearsCount, 'years').isAfter(moment(v)) || message
};
