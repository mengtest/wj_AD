//------------------------------------------------------------------------------
// Copyright (c) 2018-2019 Beijing Bytedance Technology Co., Ltd.
// All Right Reserved.
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
//------------------------------------------------------------------------------

namespace ByteDance.Union
{
#if UNITY_EDITOR || (!UNITY_ANDROID && !UNITY_IOS)
    using UnityEngine;

    /// <summary>
    /// Full screen video ad.
    /// </summary>
    public sealed class LGExpressFullscreenAd
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDance.Union.LGFullScreenVideoAd"/> class.
        /// </summary>
        /// <param name="javaObject">Java object.</param>
        internal LGExpressFullscreenAd(AndroidJavaObject javaObject)
        {
        }


        /// <summary>
        /// Shows the full screen video ad.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public void ShowExpressFullScreenAd()
        {
        }

        /// <summary>
        /// Shows the full screen video ad.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public void ShowExpressFullScreenAdWithScene(string scene)
        {
        }


        /// <summary>
        /// Sets the interaction callback.
        /// </summary>
        /// <param name="interactionCallbackC">Interaction callback c.</param>
        public void SetInteractionCallback(ILGFullScreenVideoAdInteractionCallback interactionCallbackC)
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
