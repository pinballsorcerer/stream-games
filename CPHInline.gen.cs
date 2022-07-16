using System.Collections.Generic;
using Plugins;

public partial class CPHInline
{
    /*
    Known 'args' keys:
    command
    rawInput
    rawInputEscaped
    rawInputUrlEncoded
    input0
    inputEscaped0
    inputUrlEncoded0
    counter
    userCounter
    user
    userName
    userId
    isSubscribed
    isModerator
    isVip
    broadcastUser
    broadcastUserName
    broadcastUserId
    broadcasterIsAffiliate
    broadcasterIsPartner
    randomUser0
    randomUserName0
    randomUserId0
    randomUser1
    randomUserName1
    randomUserId1
    randomUser2
    randomUserName2
    randomUserId2
    */
    protected Dictionary<string, object> args;

    protected InlineInvokeProxy CPH { get; private set; }
}
