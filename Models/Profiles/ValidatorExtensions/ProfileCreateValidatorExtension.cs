﻿using Models.Common.APIResponses;

namespace Models.Profiles.ValidatorExtensions
{

    public static class ProfileCreateValidatorExtension {

        public static List<ValidationErrorMessage> Validate(this ProfileCreateModel profileCreateModel)
        {
            var results = ((ProfileModelBase)profileCreateModel).Validate();


            results.AddRange(profileCreateModel.Addresses.Validate());

            return results;
        }
    }

}
