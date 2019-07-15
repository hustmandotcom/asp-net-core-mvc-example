using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreMvcExample.Services;
using NUnit.Framework;

namespace AspNetCoreMvcExample.UnitTests
{
    class PokerCardRankServiceTests
    {
        private PokerCardsRankService _pokerCardRankService;
        private PokerCardDealingService _pokerCardDealingService;

        [SetUp]
        public void Setup()
        {
            _pokerCardRankService = new PokerCardsRankService();
            _pokerCardDealingService = new PokerCardDealingService();
        }
    }
}
