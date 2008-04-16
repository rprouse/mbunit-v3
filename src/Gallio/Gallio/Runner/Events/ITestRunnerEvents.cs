﻿using System;

namespace Gallio.Runner.Events
{
    /// <summary>
    /// Declares all of the events that may be raised by a <see cref="ITestRunner" />.
    /// </summary>
    public interface ITestRunnerEvents
    {
        /// <summary>
        /// The event raised to indicate that the test runner initialization has started.
        /// </summary>
        event EventHandler<InitializeStartedEventArgs> InitializeStarted;

        /// <summary>
        /// The event raised to indicate that the test runner initialization has finished.
        /// </summary>
        event EventHandler<InitializeFinishedEventArgs> InitializeFinished;

        /// <summary>
        /// The event raised to indicate that the test runner disposal has started.
        /// </summary>
        event EventHandler<DisposeStartedEventArgs> DisposeStarted;

        /// <summary>
        /// The event raised to indicate that the test runner disposal has finished.
        /// </summary>
        event EventHandler<DisposeFinishedEventArgs> DisposeFinished;

        /// <summary>
        /// The event raised to indicate that a test package is being loaded.
        /// </summary>
        event EventHandler<LoadStartedEventArgs> LoadStarted;

        /// <summary>
        /// The event raised to indicate that a test package has finished loading.
        /// </summary>
        event EventHandler<LoadFinishedEventArgs> LoadFinished;

        /// <summary>
        /// The event raised to indicate that test exploration has started.
        /// </summary>
        event EventHandler<ExploreStartedEventArgs> ExploreStarted;

        /// <summary>
        /// The event raised to indicate that test exploration has finished.
        /// </summary>
        event EventHandler<ExploreFinishedEventArgs> ExploreFinished;

        /// <summary>
        /// The event raised to indicate that test execution has started.
        /// </summary>
        event EventHandler<RunStartedEventArgs> RunStarted;

        /// <summary>
        /// The event raised to indicate that test execution has finished.
        /// </summary>
        event EventHandler<RunFinishedEventArgs> RunFinished;

        /// <summary>
        /// The event raised to indicate that a test package is being unloaded.
        /// </summary>
        event EventHandler<UnloadStartedEventArgs> UnloadStarted;

        /// <summary>
        /// The event raised to indicate that a test package has finished unloading.
        /// </summary>
        event EventHandler<UnloadFinishedEventArgs> UnloadFinished;

        /// <summary>
        /// The event raised to indicate that a test step has started execution.
        /// </summary>
        event EventHandler<TestStepStartedEventArgs> TestStepStarted;

        /// <summary>
        /// The event raised to indicate that a test step has finished execution.
        /// </summary>
        event EventHandler<TestStepFinishedEventArgs> TestStepFinished;

        /// <summary>
        /// The event raised to indicate that a test step has entered a new lifecycle phase.
        /// </summary>
        event EventHandler<TestStepLifecyclePhaseChangedEventArgs> TestStepLifecyclePhaseChanged;

        /// <summary>
        /// The event raised to indicate that a test step dynamically added metadata to itself.
        /// </summary>
        event EventHandler<TestStepMetadataAddedEventArgs> TestStepMetadataAdded;

        /// <summary>
        /// The event raised to indicate that a text attachment has been added to a test step log.
        /// </summary>
        event EventHandler<TestStepLogTextAttachmentAddedEventArgs> TestStepLogTextAttachmentAdded;

        /// <summary>
        /// The event raised to indicate that a binary attachment has been added to a test step log.
        /// </summary>
        event EventHandler<TestStepLogBinaryAttachmentAddedEventArgs> TestStepLogBinaryAttachmentAdded;

        /// <summary>
        /// The event raised to indicate that text has been written to a test step log stream.
        /// </summary>
        event EventHandler<TestStepLogStreamTextWrittenEventArgs> TestStepLogStreamTextWritten;

        /// <summary>
        /// The event raised to indicate that an attachment has been embedded into a test step log stream.
        /// </summary>
        event EventHandler<TestStepLogStreamAttachmentEmbeddedEventArgs> TestStepLogStreamAttachmentEmbedded;

        /// <summary>
        /// The event raised to indicate that a section has been started within a test step log stream.
        /// </summary>
        event EventHandler<TestStepLogStreamSectionStartedEventArgs> TestStepLogStreamSectionStarted;

        /// <summary>
        /// The event raised to indicate that a section has finished within a test step log stream.
        /// </summary>
        event EventHandler<TestStepLogStreamSectionFinishedEventArgs> TestStepLogStreamSectionFinished;
    }
}
