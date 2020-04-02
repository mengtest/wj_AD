//------------------------------------------------------------------------------
// Copyright (c) 2018-2019 Beijing Bytedance Technology Co., Ltd.
// All Right Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
//------------------------------------------------------------------------------

namespace ByteDance.Union
{
#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IOS)
    using System;
    using UnityEngine;

    /// <summary>
    /// The Reward Ad.
    /// </summary>
    public sealed class LGExpressRewardAd : IDisposable
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDance.Union.LGRewardVideoAd"/> class.
        /// </summary>
        /// <param name="LGExpressRewardAdObj">Reward video ad object.</param>
        internal LGExpressRewardAd(AndroidJavaObject rewardVideoAdObj)
        {
        }

        /// <summary>
        /// Shows the reward video ad.
        /// </summary>
        public void ShowExpressRewardAd()
        {
        }

        /// <summary>
        /// Shows the reward video ad.
        /// </summary>
        public void ShowExpressRewardAdWithScene(LGBURitSceneType type, string scene)
        {
        }


        /// <summary>
        /// Sets the interaction callback.
        /// </summary>
        /// <param name="interactionCallback">Interaction callback.</param>
        public void SetInteractionCallback(ILGRewardAdInteractionCallback interactionCallback)
        {
        }

        /// <summary>
        /// Sets the download callback.
        /// </summary>
        /// <param name="downloadCallback">Download callback.</param>
        public void SetDownloadCallback(ILGAppDownloadCallback downloadCallback)
        {
        }

        /// <summary>
        /// Gets the type of the interaction.
        /// </summary>
        /// <returns>The interaction type.</returns>
        public LGAdInteractionType GetInteractionType()
        {
            return LGAdInteractionType.UNKNOWN;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
        }

    }
#endif
}
